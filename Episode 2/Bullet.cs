using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    //Our Damage Variable
    public float Damage;
    
    //When the bullet collides with something
    private void OnCollisionEnter(Collision collision)
    {
        //Send a message to the Log saying Bullet hit object
        Debug.Log("Bullet hit object");
        //Destroy the bullet object
        Destroy(this.gameObject);
    
        
        //Get the Living Script of the object 
        Living l = collision.gameObject.GetComponent<Living>();
        //If the object has a Living script
        if(l != null)
        {
            //Then do Damage
            l.Damage(Damage);
        }

    }
    
    //When the script starts
    private void Start()
    {
        //Start the startLife coroutine
        StartCoroutine(startLife());
    }
    
    //Our startLife IEnumerator
    public IEnumerator startLife()
    {
        //Wait for 2 Seconds
        yield return new WaitForSeconds(2);
        //Send a message to the log saying Bullet reached its range
        Debug.Log("Bullet reached its range");
        //Destroy the bullet
        Destroy(this.gameObject);
    }
}
