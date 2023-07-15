using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class honeyCell : MonoBehaviour
{
    public Sprite emptyCell;
    public Sprite filledCell;
    public bool isEmpty = true;

    private SpriteRenderer sr;

    void toggleCell()
    {
        isEmpty = !isEmpty;
        sr.sprite = isEmpty ? emptyCell : filledCell;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}