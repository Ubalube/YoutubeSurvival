using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Damage;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit object");
        Destroy(this.gameObject);

        Living l = collision.gameObject.GetComponent<Living>();
        if(l != null)
        {
            l.Damage(Damage);
        }

    }

    private void Start()
    {
        StartCoroutine(startLife());
    }

    public IEnumerator startLife()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Bullet reached its range");
        Destroy(this.gameObject);
    }
}
