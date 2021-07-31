using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(StickmenLeadingGroupSearcher))]
public class StickmenLeadingGroupPosition : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector3> LeadingPositionChanged;

    private StickmenLeadingGroupSearcher _leadingGroupSearcher;

    private void Awake()
    {
        _leadingGroupSearcher = GetComponent<StickmenLeadingGroupSearcher>();
    }

    private void Update()
    {
        if (_leadingGroupSearcher.Empty) return;
        Vector3 position = GetAverageLeadingGroupPosition(_leadingGroupSearcher.LeadingGroup);
        CallLeadingPositionUpdate(position);
    }

    private Vector3 GetAverageLeadingGroupPosition(List<Stickman> leadingGroup)
    {
        Vector3 averagePosition = Vector3.zero;

        foreach (var stickman in leadingGroup)
        {
            averagePosition += stickman.transform.position;
        }
        return averagePosition / leadingGroup.Count;
    }

    private void CallLeadingPositionUpdate(Vector3 position)
    {
        if (LeadingPositionChanged != null) LeadingPositionChanged.Invoke(position);
    }
}