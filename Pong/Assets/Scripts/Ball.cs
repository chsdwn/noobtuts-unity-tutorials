using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        //  1 <- top
        //  0 <- middle
        // -1 <- bottom
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collison information.
        // If the Ball collided with a racket, then:
        //      col.gameObject is the racket 
        //      col.transform.position is the racket's position
        //      col.collider is the racket's collider

        if (col.gameObject.name == "RacketLeft")
            calculateBallDirection("RacketLeft", col);

        if (col.gameObject.name == "RacketRight")
            calculateBallDirection("RacketRight", col);
    }

    private void calculateBallDirection(string racketName, Collision2D racketCol)
    {
        float y = hitFactor(transform.position, racketCol.transform.position, racketCol.collider.bounds.size.y);

        int x = racketName == "RacketLeft" ? 1 : -1;
        Vector2 dir = new Vector2(x, y).normalized;

        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
