using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class StickmanWallChecker : MonoBehaviour
{
    [SerializeField] private float checkTime;
    [SerializeField] private int wallsLayer;
    [SerializeField] private float wallDistance;

    [SerializeField] private UnityEvent HasWallOnWay;
    [SerializeField] private UnityEvent NoWallsOnWay;

    private Coroutine WallCheckCoroutine;

    private bool _hasWall;

    private void OnEnable()
    {
        _hasWall = true;
        WallCheckCoroutine = StartCoroutine(CheckingWall());
    }

    private void OnDisable()
    {
        _hasWall = false;
        StopCoroutine(WallCheckCoroutine);
    }

    private IEnumerator CheckingWall()
    {
        while (true)
        {
            bool hasWall = HasWall();

            if (_hasWall != hasWall)
            {
                if(_hasWall)
                {
                    if (NoWallsOnWay != null) NoWallsOnWay.Invoke();
                }
                else
                {
                    if (HasWallOnWay != null) HasWallOnWay.Invoke();
                }

                _hasWall = hasWall;            
            }

            yield return new WaitForSeconds(checkTime + Random.Range(0, 0.05f));
        }
    }

    public bool HasWall()
    {
        return GetWallDistance() <= wallDistance;
    }

    private float GetWallDistance()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10f, wallsLayer, QueryTriggerInteraction.Ignore))
        {
            return hit.distance;
        }

        return wallDistance + 1;
    }
}