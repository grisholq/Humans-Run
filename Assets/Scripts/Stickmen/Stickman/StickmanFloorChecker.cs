using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StickmanFloorChecker : MonoBehaviour
{
    [SerializeField] private float checkTime;
    [SerializeField] private int ignoredLayer;
    [SerializeField] private float onFloorDistance;
    [SerializeField] private UnityEvent<bool> OnFloorStateChanged;

    private Coroutine FloorCheckingCoroutine;

    private bool _onFloor;

    private void OnEnable()
    {
        _onFloor = true;
        FloorCheckingCoroutine = StartCoroutine(CheckingFloor());
    }

    private void OnDisable()
    {
        _onFloor = false;
        StopCoroutine(FloorCheckingCoroutine);
    }

    private IEnumerator CheckingFloor()
    {
        while (true)
        {
            bool onFloor = IsOnFloor();     
            
            if(_onFloor != onFloor)
            {
                _onFloor = onFloor;
                OnFloorStateChanged.Invoke(_onFloor);
            }

            yield return new WaitForSeconds(checkTime + Random.Range(0, 0.05f));
        }
    }

    public bool IsOnFloor()
    {
        return GetFloorDistance() <= onFloorDistance;
    }

    private float GetFloorDistance()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 40f, GetLayerMask(), QueryTriggerInteraction.Ignore))
        {
            return hit.distance;
        }

        return onFloorDistance + 1;
    }

    private int GetLayerMask()
    {
        return int.MaxValue - ignoredLayer;
    }
}