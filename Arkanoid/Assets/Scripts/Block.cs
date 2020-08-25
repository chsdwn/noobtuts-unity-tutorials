using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Destroy(this) only destroys the script.
        Destroy(gameObject);
    }
}
