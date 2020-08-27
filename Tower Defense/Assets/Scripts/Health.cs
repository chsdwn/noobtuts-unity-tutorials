using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public int Current()
    {
        return textMesh.text.Length;
    }

    public void Decrease()
    {
        if (Current() > 1)
            textMesh.text = textMesh.text.Remove(textMesh.text.Length - 1);
        else
            Destroy(transform.parent.gameObject);
    }
}
