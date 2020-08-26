using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    public bool mine;

    void Start()
    {
        mine = Random.value < 0.1;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

    private void OnMouseUpAsButton()
    {
        if (mine)
        {
            Playfield.UncoverMines();

            Debug.Log("Game Over");
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            LoadTexture(Playfield.CountAdjacentMines(x, y));

            Playfield.FloodFillUncover(x, y, new bool[Playfield.w, Playfield.h]);

            if (Playfield.IsFinished())
                Debug.Log("You Win");
        }
    }

    public void LoadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }

    public bool IsCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }
}
