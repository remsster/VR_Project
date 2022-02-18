using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectorParticles : MonoBehaviour
{
    public string TagDamage = "Enemy";
    public float DamageAmount = 2f;
    private Health ThisHealth = null;

    private void Awake()
    {
        ThisHealth = GetComponent<Health>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag(TagDamage))
        {
            ThisHealth.HealthPoints -= DamageAmount;
        }
    }

}
