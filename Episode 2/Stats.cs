using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    //Our currentHealth, currentThirst, and currentHunger number values
    public int currentHealth, currentThirst, currentHunger;
    //Our Health, Thirst, and Hunger sliders
    public Slider Health, Thirst, Hunger;
    //The time in which the hunger and thirst 
    public float hungerDecTime, thirstDecTime;
    
    //Every tick
    private void Update()
    {
        //If our current health is greater or equal to 100
        if(currentHealth >= 100)
        {
            //Start our Die method
            Die();
        }
        
        //Set the Health slider value to our current Health
        Health.value = currentHealth;
        //Set the Hunger slider value to our current Hunger
        Hunger.value = currentHunger;
        //Set the Thirst slider value to our current Thirst
        Thirst.value = currentThirst;
    }
    
    //When the script starts
    private void Start()
    {
        //Set all of our values to zero
        currentThirst = 0;
        currentHealth = 0;
        currentHunger = 0;
        
        //Start both our thirstBar and hungerBar coroutines
        StartCoroutine(thirstBar());
        StartCoroutine(hungerBar());
    }

    //Our thirstBar IEnumerator
    public IEnumerator thirstBar()
    {
        //Wait for (thirstDecTime) seconds
        yield return new WaitForSeconds(thirstDecTime);
        //If our currentThirst is greater or equal to 100
        if(currentThirst >= 100)
        {
            //add 1 current health to us (Adding health technically means removing it)
            currentHealth++;
        }
        //If not
        else
        {
            //Add 1 current Thirst to us (This decreases it)
            currentThirst++;
        }

        //Restart the Coroutine
        StartCoroutine(thirstBar());

    }

    //Our hungerBar IEnumerator
    public IEnumerator hungerBar()
    {
        //Wait for (hungerDecTime) seconds
        yield return new WaitForSeconds(hungerDecTime);
        //If our currentHunger is greater or equal to 100
        if(currentHunger >= 100)
        {
            //add 1 current health to us (Adding health technically means removing it)
            currentHealth++;
        }
        //If not
        else
        {
            //Add 1 current Hunger to us (This decreases it)
            currentHunger++;
        }


        //Restart the Coroutine
        StartCoroutine(hungerBar());
    }
    
    //Our Die method
    public void Die()
    {
        //Destroy the player object
        Destroy(this.gameObject);
    }

}
