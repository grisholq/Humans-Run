using UnityEngine;
using System.Collections.Generic;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Transform boss;
    [SerializeField] private float _stickmanSpeed;
    private List<Stickman> _stickmen;

    private void Awake()
    {
        _stickmen = new List<Stickman>();
    }

    private void Update()
    {
        ProcessFight();
    }

    public void AddStickmanToFight(Stickman stickman)
    {
        stickman.Mover.enabled = false;
        _stickmen.Add(stickman);
    }

    public void ProcessFight()
    {
        if (boss == null) return;

        foreach (var stickman in _stickmen)
        {
            Vector3 position = stickman.transform.position;
            position = Vector3.MoveTowards(position, boss.position, _stickmanSpeed * Time.deltaTime);
            stickman.transform.position = position;
        }
    }
}