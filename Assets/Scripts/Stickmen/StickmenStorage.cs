using UnityEngine;
using UnityEngine.Events;

public class StickmenStorage : MonoBehaviour
{
    [SerializeField] private UnityEvent NoStickmenLeft;

    public Stickman[] Array
    {
        get
        {
            return GetComponentsInChildren<Stickman>();
        }
    }

    private void Awake()
    {
        StickmenPool.Instance.ReturnedToPool += RemoveStickmen;
    }
   
    public void RemoveStickmen(Stickman stickman)
    {
        if(transform.childCount == 0)
        {
            if (NoStickmenLeft != null) NoStickmenLeft.Invoke();
        }
    }
}