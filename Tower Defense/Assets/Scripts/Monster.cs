using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject castle = GameObject.Find("Castle");
        if (castle)
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Castle")
        {
            collider.GetComponentInChildren<Health>().Decrease();
            Destroy(gameObject);
        }
    }
}
