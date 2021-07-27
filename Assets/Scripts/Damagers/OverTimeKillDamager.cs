using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(DamagerAimsFinder))]
public class OverTimeKillDamager : Damager
{
    [SerializeField] private int _killsAmount;
    [SerializeField] private float _time;

    [SerializeField] private UnityEvent<int> KillingsHappend;

    private Coroutine _killingsHandler;

    private DamagerAimsFinder _aimsFinder;

    private void OnEnable()
    {
        _aimsFinder = GetComponent<DamagerAimsFinder>();
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
            List<IDamagable> damagables = _aimsFinder.FindAims();
            KillDamagables(damagables, _killsAmount);
        }
    }

    private void KillDamagables(List<IDamagable> damagables, int amount)
    {
        int killAmount = amount > damagables.Count ? damagables.Count : amount;

        for (int i = 0; i < killAmount; i++)
        {
            damagables[i].Kill();
        }

        if (KillingsHappend != null) KillingsHappend.Invoke(killAmount);
    }
}