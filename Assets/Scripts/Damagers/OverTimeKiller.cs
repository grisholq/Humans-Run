using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(DamagerAimsFinder))]
public class OverTimeKiller : Damager
{
    [SerializeField] private int _killsAmount;
    [SerializeField] private float _time;

    [SerializeField] private UnityEvent<int> KillingsHappend;

    private Coroutine _killingsHandler;

    private DamagerAimsFinder _aimsFinder;

    private void Awake()
    {
        _aimsFinder = GetComponent<DamagerAimsFinder>();
    }

    private void OnEnable()
    {        
        _killingsHandler = StartCoroutine(HandleKilling());
    }

    private void OnDisable()
    {
        StopCoroutine(_killingsHandler);
    }

    private IEnumerator HandleKilling()
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);
            KillDamagables(_aimsFinder.FindAims(), _killsAmount);
        }
    }

    private void KillDamagables(List<IDamagable> damagables, int amount)
    {
        if (damagables == null || damagables.Count == 0) return;

        int killAmount = amount > damagables.Count ? damagables.Count : amount;

        for (int i = 0; i < killAmount; i++)
        {
            damagables[i].Kill();
        }

        CallKillingsHappend(amount);
    }

    private void CallKillingsHappend(int amount)
    {
        if (KillingsHappend != null) KillingsHappend.Invoke(amount);
    }
}