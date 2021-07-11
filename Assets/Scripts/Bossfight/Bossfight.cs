using UnityEngine;
using System.Collections.Generic;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Transform _boss;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;
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
        stickman.Speed = 0.11f;
        _stickmen.Add(stickman);
    }

    public void ProcessFight()
    {
        if (_boss == null) return;

        foreach (var stickman in _stickmen)
        {
            if (Vector3.Distance(stickman.transform.position, _boss.position) > _stopDistance)
            {
                Vector3 position = stickman.transform.position;
                position = Vector3.MoveTowards(position, _boss.position, _speed * Time.deltaTime);
                stickman.transform.position = position;
            }
            else
            {
                stickman.IsFighting = true;
            }
        }
    }
}