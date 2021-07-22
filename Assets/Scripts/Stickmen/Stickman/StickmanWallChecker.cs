using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class StickmanWallChecker : MonoBehaviour
{
    [SerializeField] private List<int> _checkLayers;

    [SerializeField] private UnityEvent NearedToWall;
    [SerializeField] private UnityEvent NoWallOnWay;

    private bool _hasWall;

    public bool HasWall
    {
        get
        {
            return _hasWall;
        }

        set
        {
            if(_hasWall != value)
            {
                if(_hasWall == true)
                {
                    NoWallOnWay.Invoke();
                }
                else
                {
                    NearedToWall.Invoke();
                }

                _hasWall = value;
            }
        }
    }


    private void Awake()
    {
        _hasWall = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_checkLayers.Contains(other.gameObject.layer))
        {
            
            HasWall = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (_checkLayers.Contains(other.gameObject.layer))
        {
            HasWall = false;
        }
    }
}