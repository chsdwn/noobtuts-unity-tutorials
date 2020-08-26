using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;

    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;

    void Start()
    {
        InvokeRepeating("Move", .3f, .3f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.StartsWith("FoodPrefab"))
        {
            ate = true;

            Destroy(col.gameObject);
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    void Move()
    {
        // Fills gap with the last element of tail.
        // Inserts last element to first and removes last
        Vector2 headPosition = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            GameObject insertedTail = (GameObject)Instantiate(tailPrefab, headPosition, Quaternion.identity);

            tail.Insert(0, insertedTail.transform);

            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = headPosition;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
