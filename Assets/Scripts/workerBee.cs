using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerBee : MonoBehaviour
{
    public float timeToReachFlower = 2.0f;
    public float timeToReachHoneyCell = 2.0f;

    private beeTrafficController hiveMind;
    private GameObject[] flowers;
    private honeyCell targetCell;
    private IEnumerator animationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        hiveMind = GameObject.FindGameObjectWithTag("HiveMind").GetComponent<beeTrafficController>();
        goToFlower();
    }

    public void goToFlower()
    {
        Vector3 flowerPosition = flowers[UnityEngine.Random.Range(0, flowers.Length)].transform.position;
        animationCoroutine = AnimateVector3(timeToReachFlower, transform.position, flowerPosition, pollenate);
        StartCoroutine(animationCoroutine);
    }

    private void pollenate()
    {
        hiveMind.pollinatedBees.Enqueue(this);
    }

    public void targetEmptyCell(honeyCell cell)
    {
        targetCell = cell;
        animationCoroutine = AnimateVector3(timeToReachHoneyCell, transform.position, targetCell.GetComponent<Transform>().position, depositHoney);
        StartCoroutine(animationCoroutine);
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
