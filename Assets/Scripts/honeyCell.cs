using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class honeyCell : MonoBehaviour
{
    public Sprite filledCell;
    public bool isEmpty = true;
    public beeTrafficController hiveMind;
    public GameObject workerBee;

    private SpriteRenderer sr;

    public void empty()
    {
        isEmpty = true;
        sr.sprite = null;
        hiveMind.emptyCells.Enqueue(this);
    }

    public void fill()
    {
        isEmpty = false;
        sr.sprite = filledCell;
    }

    public void spawnBee()
    {
        empty();
        workerBee newBee = Instantiate(workerBee, transform.position, Quaternion.identity).GetComponent<workerBee>();
        newBee.hiveMind = hiveMind;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (isEmpty && hiveMind != null)
        {
            hiveMind.emptyCells.Enqueue(this);
        }
    }
}