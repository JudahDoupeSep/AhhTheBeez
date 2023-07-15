using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class honeyCell : MonoBehaviour
{
    public Sprite emptyCell;
    public Sprite filledCell;
    public bool isEmpty = true;
    public beeTrafficController hiveMind;

    private SpriteRenderer sr;

    public void empty()
    {
        isEmpty = true;
        sr.sprite = emptyCell;
        hiveMind.emptyCells.Enqueue(this);
    }

    public void fill()
    {
        isEmpty = false;
        sr.sprite = filledCell;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}