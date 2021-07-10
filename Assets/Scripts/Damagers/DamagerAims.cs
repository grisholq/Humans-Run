using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DamagerAims : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _aimsLayer;

    [SerializeField] private UnityEvent<bool> HasAims;

    private void Start()
    {
        StartCoroutine(FindAims());
    }

    private IEnumerator FindAims()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            HasAims.Invoke(IsAimsInRange());
        }
    }

    private bool IsAimsInRange()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(_range, _range, _range), Quaternion.identity, _aimsLayer, QueryTriggerInteraction.Collide);
        return colliders != null && colliders.Length != 0;
    }
}