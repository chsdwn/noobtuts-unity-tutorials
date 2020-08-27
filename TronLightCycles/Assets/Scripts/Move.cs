using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public GameObject wallPrefab;
    public float speed = 16;

    Collider2D wall;
    Vector2 lastWallEnd;
    bool IsDirectionUp = false;
    bool IsDirectionDown = false;
    bool IsDirectionRight = false;
    bool IsDirectionLeft = false;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        SpawnWall();
        IsDirectionDown = true;
        // InvokeRepeating("SpawnWall", 0f, .05f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey) && !IsDirectionDown)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            SpawnWall();
            IsDirectionUp = true;
            IsDirectionDown = false;
            IsDirectionRight = false;
            IsDirectionLeft = false;
        }
        else if (Input.GetKeyDown(downKey) && !IsDirectionUp)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
            SpawnWall();
            IsDirectionUp = false;
            IsDirectionDown = true;
            IsDirectionRight = false;
            IsDirectionLeft = false;
        }
        else if (Input.GetKeyDown(rightKey) && !IsDirectionLeft)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            SpawnWall();
            IsDirectionUp = false;
            IsDirectionDown = false;
            IsDirectionRight = true;
            IsDirectionLeft = false;
        }
        else if (Input.GetKeyDown(leftKey) && !IsDirectionRight)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            SpawnWall();
            IsDirectionUp = false;
            IsDirectionDown = false;
            IsDirectionRight = false;
            IsDirectionLeft = true;
        }

        FitColliderBetween(wall, lastWallEnd, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != wall)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    void SpawnWall()
    {
        lastWallEnd = transform.position;

        GameObject g = Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }

    void FitColliderBetween(Collider2D collider, Vector2 a, Vector2 b)
    {
        collider.transform.position = a + (b - a) * .5f;

        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            // use, the transform.localScale property to make it really long
            // so it fits exactly between the points
            collider.transform.localScale = new Vector2(dist + 1, 1);
        else
            collider.transform.localScale = new Vector2(1, dist + 1);
    }
}
