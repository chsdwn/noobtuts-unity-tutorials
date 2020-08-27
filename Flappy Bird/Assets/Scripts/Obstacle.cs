using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0;
    public float switchTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        InvokeRepeating("Switch", 0, switchTime);
    }

    void Switch()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
}
