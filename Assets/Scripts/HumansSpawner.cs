using UnityEngine;

public class HumansSpawner : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _spawnPosition;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnHuman();
            SpawnHuman();
            SpawnHuman();
            SpawnHuman();
            SpawnHuman();
        }
    }

    private void SpawnHuman()
    {
        Transform human = Instantiate(_prefab);
        human.position = GetRandomPositionInRadius(_spawnPosition.position, 1);
    }

    private Vector3 GetRandomPositionInRadius(Vector3 position, float radius)
    {
        return position + new Vector3(1, 0, 1) * Random.Range(-radius, radius);
    }
}