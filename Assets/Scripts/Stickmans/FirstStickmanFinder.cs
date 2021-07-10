using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Stickmen))]
public class FirstStickmanFinder : MonoBehaviour
{
    [SerializeField] private UnityEvent<Transform> FirstStickmanFound;
    private Stickmen _stickmen;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
    }

    private void Start()
    {
        StartCoroutine(UpdatingFirstStickman());
    }

    private IEnumerator UpdatingFirstStickman()
    {
        while(true)
        {
            Stickman stickman;
            if (GetFirstStickman(out stickman))
            {
                _stickmen.First = stickman;
                if (FirstStickmanFound != null) FirstStickmanFound.Invoke(stickman.transform);
            }
            
            yield return new WaitForSeconds(0.2f);        
        }
    }

    public bool GetFirstStickman(out Stickman stickman)
    {
        List<Stickman> stickmen = _stickmen.StickmenList;

        if (stickmen == null || stickmen.Count == 0)
        {
            stickman = null;
            return false;
        }

        int index = 0;
        float z = 0;

        for (int i = 0; i < stickmen.Count; i++)
        {
            if(stickmen[i].transform.position.z >= z)
            {
                z = stickmen[i].transform.position.z;
                index = i;
            }
        }

        stickman = stickmen[index];

        return true;
    }
}