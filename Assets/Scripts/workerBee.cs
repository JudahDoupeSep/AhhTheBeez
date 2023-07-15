using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerBee : MonoBehaviour
{
    public float timeToReachFlower = 2.0f;
    public float timeToReachHoneyCell = 2.0f;
    public beeTrafficController hiveMind;
    public Transform flowerPosition; // TODO: need to find a way for any newly created bee to know where flowers are.

    private honeyCell targetCell;

    // Start is called before the first frame update
    void Start()
    {
        goToFlower();
    }

    private void goToFlower()
    {
        AnimateVector3(timeToReachFlower, transform.position, flowerPosition.position, pollenate);
    }

    private void pollenate()
    {
        hiveMind.pollinatedBees.Enqueue(this);
    }

    public void targetEmptyCell(honeyCell cell)
    {
        targetCell = cell;
        AnimateVector3(timeToReachHoneyCell, transform.position, targetCell.GetComponent<Transform>().position, depositHoney);
    }

    private void depositHoney()
    {
        targetCell.fill();
        goToFlower();
    }

    private void setPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private IEnumerator AnimateVector3(float seconds, Vector3 start, Vector3 end, Action callback)
    {
        var remainingSeconds = seconds;
        var t = 0f;
        while (t < 1)
        {
            yield return new WaitForEndOfFrame();
            setPosition(Vector3.Lerp(start, end, t));
            remainingSeconds -= Time.deltaTime;
            t = 1 - (remainingSeconds / seconds);
        }
        setPosition(end);
        callback.Invoke();
    }
}
