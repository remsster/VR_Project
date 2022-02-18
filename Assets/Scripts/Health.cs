using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHealthChanged;
    public string SpawnPoolTag = string.Empty;
    public float HealthPoints
    {
        get => _HealthPoints;
        set
        {
            _HealthPoints = value;
            // Event is invoked if OnHealthChanges is not null
            OnHealthChanged?.Invoke();
            if (_HealthPoints <= 0f) { Die(); }
        }
    }

    [SerializeField]
    private float _HealthPoints = 100f;
    private ObjectPool Pool;


    private void Awake()
    {
        if (SpawnPoolTag.Length > 0)
        {
            Pool = GameObject.FindWithTag(SpawnPoolTag).GetComponent<ObjectPool>();
        }
    }

    private void Die()
    {
        if(Pool != null)
        {
            Pool.DeSpawn(transform);
            HealthPoints = 100;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HealthPoints = 0;
        }
    }
}
