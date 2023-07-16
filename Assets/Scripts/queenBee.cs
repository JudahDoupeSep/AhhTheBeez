using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class queenBee : MonoBehaviour
{
    private honeyCell[] honeyCells;
    private float timeLastHarvested = 0;
    private honeyCounter totalHoney;
    private beeCounter totalBees;

    public float timeToWait = 5f;
    public float timeBetweenCollection = 0.15f; 
    public int workerBeePrice = 3;
    public float scale = 0.3f;
    public GameObject workerBee;
    public GameObject hive;

    public PriceDisplay priceDisplay;

    private int count = 0;
    public AudioClip Buzz;
    public void setHive(GameObject hive)
    {
        honeyCells = hive.GetComponentsInChildren<honeyCell>();
    }

    // Start is called before the first frame update
    void Start() 
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
        totalBees = controller.GetComponent<beeCounter>();
        if (hive != null)
        {
            setHive(hive);
        }
        priceDisplay.UpdatePrice(workerBeePrice);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeToWait  > timeLastHarvested)
        {
            timeLastHarvested = Time.time;
            foreach (var cell in honeyCells)
            {
                if (cell.isEmpty == false)
                {
                    count++;
                }
            }
            StartCoroutine(harvest());
        }
    }

    IEnumerator harvest()
    {
        foreach (var cell in honeyCells)
        {
            if (count != 0)
            {
                cell.empty();
                count--;
                yield return new WaitForSeconds(timeBetweenCollection);
            } 
            else
            {
                StopCoroutine(harvest());
            }
        }
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney > workerBeePrice)
        {
            totalHoney.totalHoney -= workerBeePrice;
            Instantiate(workerBee, transform.position, Quaternion.identity);
            totalBees.totalBees++;
            workerBeePrice = (int)(scale * totalBees.totalBees + workerBeePrice);
            priceDisplay.UpdatePrice(workerBeePrice);
            audioManager.PlaySound(Buzz);
        }
    }
    
    

    private void OnMouseEnter()
    {
        priceDisplay.ShowName();
    }

    private void OnMouseExit()
    {
        priceDisplay.HideName();
    }
}
