using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBee : MonoBehaviour
{
    private honeyCell[] honeyCells;
    private float timeLastHarvested = 0;

    public float timer = 10;
    
    public void setHive(GameObject hive)
    {
        honeyCells = hive.GetComponentsInChildren<honeyCell>();
    }

    // Start is called before the first frame update
    void Start() {}

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
}
