using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmenCameraPositioner : MonoBehaviour
{
    [SerializeField] private CameraFollower _follower;
   
    private Stickmen _stickmen;
    private List<Stickman> _firstStickmen;
    private IComparer<Stickman> _comparer;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
        _firstStickmen = new List<Stickman>();
        _comparer = new StickmanAxisZComparer();
    }

    private void Start()
    {
        StartCoroutine(UpdatingCameraPosition());
    }

    private void Update()
    {
        PositionCamera();
    }

    private IEnumerator UpdatingCameraPosition()
    {
        while (true)
        {
            SetFirstStickmen();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void PositionCamera()
    {
        if(_firstStickmen == null || _firstStickmen.Count == 0)
        {
            return;
        }

        Vector3 position = GetAveragePosition(_firstStickmen);
        _follower.Position = position;
    }

    private void SetFirstStickmen()
    {
        List<Stickman> stickmen = new List<Stickman>(_stickmen.List);

        if (stickmen == null || stickmen.Count == 0)
        {
            return;
        }

        stickmen.Sort(_comparer);

        _firstStickmen.Clear();

        if (stickmen.Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                _firstStickmen.Add(stickmen[i]);
            }
        }
        else
        {
            _firstStickmen.Add(stickmen[0]);
        }
    }

    private Vector3 GetAveragePosition(List<Stickman> stickmen)
    {
        Vector3 result = Vector3.zero;

        foreach (var stickman in stickmen)
        {
            result += stickman.transform.position;
        }

        return result / stickmen.Count;
    }
}