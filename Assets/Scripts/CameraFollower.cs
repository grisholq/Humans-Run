using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _followed;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _eulers;

    private void Start()
    {
        transform.eulerAngles = _eulers;
    }

    private void Update()
    {
        if(_followed != null)
        {
            transform.position = _followed.position + _offset;
        }
    }
}