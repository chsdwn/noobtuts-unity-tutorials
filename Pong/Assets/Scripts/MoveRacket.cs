using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public enum Axises
    {
        Vertical,
        Vertical2,
    }

    public float speed = 30;
    public Axises axis = Axises.Vertical | Axises.Vertical2;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis.ToString());
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
