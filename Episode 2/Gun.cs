using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //The number of bullets the gun will have (ammo capacity)
    public int ammo;
    //The current number of bullets the gun has 
    private int currentAmmo;
    //Is the gun automatic? (Can you hold down left click to shoot?)
    public bool isAutomatic;
    
    //The bullet object we are shooting
    public GameObject bullet;
    //3 values, the damage of the bullet, the firerate of the bullet, and the force of the bullet (the velocity)
    public float damage, firerate, force;
    //How much time to wait until we can fire again. Used for firerate.
    private float nextTimeToFire = 0.0f;

    //How long it takes it to reload
    public float reloadTime;
    
    //Are we reloading
    public bool isReloading;
    
    //The location at which the bullet spawns
    public Transform shootLoc;
    
    //When the script starts
    private void Start()
    {
        //Sets the current ammo to full
        currentAmmo = ammo;
    }
    
    //Every 20 ticks
    private void Update()
    {
        
        //If we press the R key on our keyboard and our current ammo is NOT equal to the ammo capacity (if it is not full)
        //and we are NOT reloading then...
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != ammo && !isReloading)
        {
            //Start our Reload method
            Reload();
        }
        
        //If our currentAmmo less than or equal to zero, if it is empty, then...
        if(currentAmmo <= 0)
        {
            //Send a message to the console saying Out of Ammo!
            Debug.Log("Out of Ammo!");
        }
        //If the ammo is not empty
        else
        {   
            //If the gun is automatic
            if (isAutomatic)
            {
                //If we are holding down the left click button and the current time is greater than the next time to fire
                //and we are not reloading
                if (Input.GetMouseButton(0) && Time.time > nextTimeToFire && !isReloading)
                {
                    //Set the next time to fire to the time plus 1 divided by firerate
                    nextTimeToFire = Time.time + 1f / firerate;
                    //Call our Shoot method
                    Shoot();
                }
            }
            //If its not Automatic
            else
            {   
                
                //If we are holding down the left click button and the current time is greater than the next time to fire
                //and we are not reloading
                if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && !isReloading)
                {
                    //Set the next time to fire to the time plus 1 divided by firerate
                    nextTimeToFire = Time.time + 1f / firerate;
                    //Call our Shoot method
                    Shoot();
                }
            }
        }

    }

    //The Reload method
    public void Reload()
    {
        //Start our Coroutine called startReload
        StartCoroutine(startReload());
        //Set isReloading to true
        isReloading = true;
    }
    
    //Our startReload IEnumerator
    public IEnumerator startReload()
    {
        //Send a message to the Log saying Taking Magazine Out
        Debug.Log("Taking Magazine Out");
        //Wait for (reloadTime) amount of seconds
        yield return new WaitForSeconds(reloadTime);
        //Send a message to the Log saying Putting Magazine In
        Debug.Log("Putting Magazine In");
        //Set the current ammo to the ammo capacity
        currentAmmo = ammo;
        //Set isReloading to false
        isReloading = false;
    }

    //Our Shoot Method
    public void Shoot()
    {
        //Take 1 of our current ammo away (currentAmmo-- can also be currentAmmo - 1)
        currentAmmo--;
        //Define Bullet b to the object we instantiate (create) at the shootLoc position and rotate it automatically
        Bullet b = Instantiate(bullet, shootLoc.position, Quaternion.identity).GetComponent<Bullet>();
        //Get the Rigidbody Script and set the velocity to the shootLoc's direction and go forward * the force.
        b.GetComponent<Rigidbody>().velocity = shootLoc.TransformDirection(Vector3.forward * force);
        //Rotate the bullet to the shootLoc's rotation
        b.transform.rotation = shootLoc.rotation;
        //Set the bullet damage
        b.Damage = this.damage;
    }

}
