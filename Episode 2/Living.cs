using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    public float Health;
    private float currentHealth;

    private void Start()
    {
        currentHealth = Health;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

}
