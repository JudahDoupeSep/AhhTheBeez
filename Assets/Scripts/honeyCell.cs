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
        if (!isEmpty)
        {
            isEmpty = true;
            sr.sprite = null;
            hiveMind.emptyCells.Enqueue(this);
            honeyCounter.totalHoney += increment;
            var sound = GetComponent<AudioSource>();
            sound.pitch = Random.Range(0.5f, 1f);
            sound.Play();
        }
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
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        hiveMind = controller.GetComponent<beeTrafficController>();
        honeyCounter = controller.GetComponent<honeyCounter>();
        isEmpty = true;
        sr.sprite = null;
        hiveMind.emptyCells.Enqueue(this);
    }

    private void OnMouseDown()
    {
        empty(manualClick);
    }
}
