using UnityEngine;
using UnityEngine.Events;

public class StickmenStorage : MonoBehaviour
{
    [SerializeField] private UnityEvent NoStickmenLeft;

    public Stickman[] Stickmen
    {
        get
        {
            return GetComponentsInChildren<Stickman>();
        }
    }

    public int StickmenCount => transform.childCount;

    public bool Empty => transform.childCount == 0;

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