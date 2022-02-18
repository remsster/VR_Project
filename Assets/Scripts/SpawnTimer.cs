using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public string SpawnPoolTag = "Enemy Pool";
    public float SpawnIntival = 5f;
    private ObjectPool Pool = null;

    private void Awake()
    {
        Pool = GameObject.FindGameObjectWithTag(SpawnPoolTag).GetComponent<ObjectPool>();
    }

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnIntival, SpawnIntival);
    }

    public void Spawn()
    {
        Pool.Spawn(null, transform.position, transform.rotation, Vector3.one);
    }
}
