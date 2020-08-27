using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Transform target;

    private void FixedUpdate()
    {
        if (target)
        {

            Vector3 dir = target.position - transform.position;
            // normalized direction to make sure that it has the length of one
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponentInChildren<Health>();
        if (health)
        {
            health.Decrease();
            Destroy(gameObject);
        }
    }
}
