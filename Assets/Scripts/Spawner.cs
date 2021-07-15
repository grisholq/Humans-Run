using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private int _lenght;
    [SerializeField] private int _width;

    private void Start()
    {
        for (int i = 0; i < _lenght; i++)
        {
            for (int i1 = 0; i1 < _width; i1++)
            {
                Transform transform = Instantiate(_prefab);
                transform.position = new Vector3(i, 0.5f, i1);
            }
        }
    }
}