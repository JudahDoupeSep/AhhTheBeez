using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBee : MonoBehaviour
{
    private honeyCell[] honeyCells;
    private float timeLastHarvested = 0;
    private honeyCounter totalHoney;

    public float timer = 10;
    public int price = 3;
    public GameObject workerBee;
    public GameObject hive;
    
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
        if (Time.time - timer  > timeLastHarvested)
        {
            timeLastHarvested = Time.time;
            foreach (var cell in honeyCells)
            {
                cell.empty();
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
