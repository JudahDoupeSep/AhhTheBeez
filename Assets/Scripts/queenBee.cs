using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBee : MonoBehaviour
{
    private honeyCell[] honeyCells;
    private float timeLastHarvested = 0;
    private honeyCounter totalHoney;

    public float timeToWait = 5f;
    public float timeBetweenCollection = 0.15f; 
    public int price = 3;
    public GameObject workerBee;
    public GameObject hive;

    private int count = 0;
    
    public void setHive(GameObject hive)
    {
        honeyCells = hive.GetComponentsInChildren<honeyCell>();
    }

    // Start is called before the first frame update
    void Start() 
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
        if (hive != null)
        {
            setHive(hive);
        }
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
        if (totalHoney.totalHoney > price)
        {
            totalHoney.totalHoney -= price;
            Instantiate(workerBee, transform.position, Quaternion.identity);
        }
    }
}
