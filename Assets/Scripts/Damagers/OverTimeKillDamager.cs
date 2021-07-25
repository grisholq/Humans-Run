using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class OverTimeKillDamager : Damager
{
    [SerializeField] private int _aimsLayer;
    [SerializeField] private int _killsAmount;
    [SerializeField] private float _range;
    [SerializeField] private float _time;

    [SerializeField] private UnityEvent<int> KillingsHappend;
    [SerializeField] private UnityEvent<int> AimsAmountUpdate;

    private Coroutine _killingCoroutine;

    private Collider[] _enemyColliders;

    private void OnEnable()
    {
        _killingCoroutine = StartCoroutine(FindDamagables());
    }

    private void OnDisable()
    {
        StopCoroutine(_killingCoroutine);
    }

    private IEnumerator FindDamagables()
    {
        while (true)
        {
            LocateNearbyEnemies();
            yield return new WaitForSeconds(_time); 
            HandleDamagablesKilling();
        }
    }

    private void LocateNearbyEnemies()
    {
        if (GetDamagablesColliders(out _enemyColliders))
        {
            if (AimsAmountUpdate != null) AimsAmountUpdate.Invoke(_enemyColliders.Length);
            return;
        }
        if (AimsAmountUpdate != null) AimsAmountUpdate.Invoke(0);
    }

    private void HandleDamagablesKilling()
    {
        if (HasEnemies() == false) return;
        IDamagable[] damagables = GetDamagablesFromColliders(_enemyColliders);
        KillDamagables(damagables, _killsAmount);      
    }

    private void KillDamagables(IDamagable[] damagables, int amount)
    {
        int lastIndexExclusive = amount > damagables.Length ? damagables.Length : amount;

        for (int i = 0; i < lastIndexExclusive; i++)
        {
            damagables[i].Kill();
        }

        if (KillingsHappend != null) KillingsHappend.Invoke(lastIndexExclusive);
    }

    private IDamagable[] GetDamagablesFromColliders(Collider[] colliders)
    {
        IDamagable[] damagables = new IDamagable[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            damagables[i] = colliders[i].GetComponent<IDamagable>();
        }

        return damagables;
    }

    private bool GetDamagablesColliders(out Collider[] colliders)
    {
        colliders = Physics.OverlapBox(transform.position, GetRange(), Quaternion.identity, _aimsLayer, QueryTriggerInteraction.Collide);
        return colliders != null && colliders.Length != 0;
    }

    private bool HasEnemies()
    {
        return _enemyColliders != null && _enemyColliders.Length != 0;
    }

    private Vector3 GetRange()
    {
        return new Vector3(_range, _range, _range);
    }
}