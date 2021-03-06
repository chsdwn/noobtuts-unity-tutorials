﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform borderTop, borderRight, borderBottom, borderLeft;

    void Start()
    {
        // Repeats Spawn function every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    private void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
