using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DamagerAims : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _aimsLayer;

    [SerializeField] private UnityEvent<int> AimsCountChanged;

    private int _aimsCount;

    private void Start()
    {
        _aimsCount = 0;
        CallAimsCountUpdate(_aimsCount);
        StartCoroutine(FindAims());
    }

    private IEnumerator FindAims()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            int count = GetAimsAmountInRange();

            if(count != _aimsCount)
            {
                _aimsCount = count;
                CallAimsCountUpdate(count);
            }          
        }
    }

    private int GetAimsAmountInRange()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(_range, _range, _range), Quaternion.identity, _aimsLayer, QueryTriggerInteraction.Collide);
        
        if(colliders != null && colliders.Length != 0)
        {
            return colliders.Length;
        }
        return 0;
    }

    private void CallAimsCountUpdate(int count)
    {
        if (AimsCountChanged != null) AimsCountChanged.Invoke(count);
    }
}