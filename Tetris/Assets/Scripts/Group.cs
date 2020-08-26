using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    float lastFall = 0;

    private void Start()
    {
        if (!IsValidGridPos())
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (IsValidGridPos())
                UpdateGrid();
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Playfield.DeleteFullRows();
                FindObjectOfType<Spawner>().SpawnNext();
                enabled = false;
            }

            lastFall = Time.time;
        }
    }

    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.RoundVec2(child.position);

            if (!Playfield.IsInsideBorder(v))
                return false;

            if (Playfield.grid[(int)v.x, (int)v.y] != null && Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }

        return true;
    }

    void UpdateGrid()
    {
        for (int y = 0; y < Playfield.h; ++y)
        {
            for (int x = 0; x < Playfield.w; ++x)
            {
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;
            }
        }

        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.RoundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
