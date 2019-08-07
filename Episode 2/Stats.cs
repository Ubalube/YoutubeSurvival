using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int currentHealth, currentThirst, currentHunger;
    public Slider Health, Thirst, Hunger;
    public float hungerDecTime, thirstDecTime;

    private void Update()
    {

        if(currentHealth >= 100)
        {
            //Die
            Die();
        }

        Health.value = currentHealth;
        Hunger.value = currentHunger;
        Thirst.value = currentThirst;
    }

    private void Start()
    {

        currentThirst = 0;
        currentHealth = 0;
        currentHunger = 0;

        StartCoroutine(thirstBar());
        StartCoroutine(hungerBar());
    }

    public IEnumerator thirstBar()
    {
        yield return new WaitForSeconds(thirstDecTime);
        if(currentThirst >= 100)
        {
            currentHealth++;
        }
        else
        {
            currentThirst++;
        }


        StartCoroutine(thirstBar());

    }

    public IEnumerator hungerBar()
    {
        yield return new WaitForSeconds(hungerDecTime);
        if(currentHunger >= 100)
        {
            currentHealth++;
        }
        else
        {
            currentHunger++;
        }


        StartCoroutine(hungerBar());
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

}
