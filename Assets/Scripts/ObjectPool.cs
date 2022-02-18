using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public int PoolSize = 10;

    private void Start()
    {
        GeneratePool();
    }

    public void GeneratePool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject Obj = Instantiate(ObjectPrefab, Vector3.zero, Quaternion.identity);
            Obj.transform.parent = this.transform;
            Obj.SetActive(false);
        }
    }

    public Transform Spawn(Transform Parent, Vector3 Position = new Vector3(), Quaternion Rotation = new Quaternion(), Vector3 Scale = new Vector3())
    {
        Debug.Log($"Bot not active yet, Child Count: {transform.childCount}");
        if (transform.childCount <= 0) { return null; }
        Transform Child = transform.GetChild(0);
        Child.SetParent(Parent);
        Child.position = Position;
        Child.rotation = Rotation;
        Child.localScale = Scale;
        Child.gameObject.SetActive(true);
        Debug.Log("Activated bot");
        return Child;

    }

    public void DeSpawn(Transform ObjectToDespawn)
    {
        ObjectToDespawn.gameObject.SetActive(false);
        ObjectToDespawn.SetParent(transform);
        ObjectToDespawn.position = Vector3.zero;
    }
}
