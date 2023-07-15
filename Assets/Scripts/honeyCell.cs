using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class honeyCell : MonoBehaviour
{
    const int manualClick = 3;

    public Sprite filledCell;
    public bool isEmpty = true;

    private beeTrafficController hiveMind;
    private honeyCounter honeyCounter;
    private SpriteRenderer sr;

    public void empty(int increment = 1)
    {
        isEmpty = true;
        sr.sprite = null;
        hiveMind.emptyCells.Enqueue(this);
        honeyCounter.totalHoney += increment;
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
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        hiveMind = controller.GetComponent<beeTrafficController>();
        honeyCounter = controller.GetComponent<honeyCounter>();
        if (isEmpty && hiveMind != null)
        {
            hiveMind.emptyCells.Enqueue(this);
        }
    }

    private void OnMouseDown()
    {
        if (!isEmpty)
        {
            empty(manualClick);
        }
    }
}