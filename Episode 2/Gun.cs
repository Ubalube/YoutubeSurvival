using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int ammo;
    private int currentAmmo;
    public bool isAutomatic;
    
    public GameObject bullet;
    public float damage, firerate, force;
    private float nextTimeToFire = 0.0f;

    public float reloadTime;
    public bool isReloading;

    public Transform shootLoc;

    private void Start()
    {
        currentAmmo = ammo;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != ammo && !isReloading)
        {
            Reload();
        }

        if(currentAmmo <= 0)
        {
            Debug.Log("Out of Ammo!");
        }
        else
        {
            if (isAutomatic)
            {
                if (Input.GetMouseButton(0) && Time.time > nextTimeToFire && !isReloading)
                {
                    nextTimeToFire = Time.time + 1f / firerate;
                    Shoot();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && !isReloading)
                {
                    nextTimeToFire = Time.time + 1f / firerate;
                    Shoot();
                }
            }
        }

    }

    public void Reload()
    {
        StartCoroutine(startReload());
        isReloading = true;
    }

    public IEnumerator startReload()
    {
        Debug.Log("Taking Magazine Out");
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Putting Magazine In");
        currentAmmo = ammo;
        isReloading = false;
    }

    public void Shoot()
    {
        currentAmmo--;
        Bullet b = Instantiate(bullet, shootLoc.position, Quaternion.identity).GetComponent<Bullet>();
        b.GetComponent<Rigidbody>().velocity = shootLoc.TransformDirection(Vector3.forward * force);
        b.transform.rotation = shootLoc.rotation;
        b.Damage = this.damage;
    }

}
