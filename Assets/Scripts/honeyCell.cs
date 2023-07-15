using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class honeyCell : MonoBehaviour
{
    public Sprite filledCell;
    public bool isEmpty = true;
    public GameObject workerBee;

    private beeTrafficController hiveMind;
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

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        hiveMind = GameObject.FindGameObjectWithTag("HiveMind").GetComponent<beeTrafficController>();
        if (isEmpty && hiveMind != null)
        {
            hiveMind.emptyCells.Enqueue(this);
        }
    }

    private void OnMouseDown()
    {
        if (!isEmpty)
        {
            empty();
            Instantiate(workerBee, transform.position, Quaternion.identity);
        }
    }
}