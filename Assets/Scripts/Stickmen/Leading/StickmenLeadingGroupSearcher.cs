using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(StickmenStorage))]
public class StickmenLeadingGroupSearcher : MonoBehaviour
{
    [SerializeField] private float _searchTime;
    [SerializeField] private int _leadingAmount;

    private StickmenStorage _stickmenStorage;
    private IComparer<Stickman> _leadComparer;

    private Coroutine _leadingGroupUpdater;

    public List<Stickman> LeadingGroup { get; private set; }
    public bool Empty => LeadingGroup == null || LeadingGroup.Count == 0;

    private void Awake()
    {
        LeadingGroup = new List<Stickman>();
        _stickmenStorage = GetComponent<StickmenStorage>();
        _leadComparer = new StickmanAxisZComparer();
    }

    private void OnEnable()
    {
        _leadingGroupUpdater = StartCoroutine(LeadingGroupUpdater());
    }

    private void OnDisable()
    {
        if (_leadingGroupUpdater != null) StopCoroutine(_leadingGroupUpdater);
    }

    private IEnumerator LeadingGroupUpdater()
    {
        while (true)
        {
            LeadingGroup = GetLeadingGroup();
            yield return new WaitForSeconds(_searchTime);           
        }
    }

    private List<Stickman> GetLeadingGroup()
    {
        if (_stickmenStorage.Empty) return null;
        List<Stickman> stickmen = _stickmenStorage.Stickmen.ToList();
        SortByLeading(stickmen);
        return GetMostLeadingStickmen(stickmen);
    }

    private void SortByLeading(List<Stickman> stickmen)
    {
        stickmen.Sort(_leadComparer);
    }

    private List<Stickman> GetMostLeadingStickmen(List<Stickman> leaders)
    {
        if (IsOptimalLeadersAmount(leaders))
        {
            return leaders.GetRange(0, _leadingAmount);
        }
        else
        {
            return leaders;
        }
    }

    private bool IsOptimalLeadersAmount(List<Stickman> stickmen)
    {
        return stickmen.Count >= _leadingAmount;
    }
}