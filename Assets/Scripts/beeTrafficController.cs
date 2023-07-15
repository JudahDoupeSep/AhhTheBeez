using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeTrafficController : MonoBehaviour
{
    public Queue<honeyCell> emptyCells;
    public Queue<workerBee> pollinatedBees;

    // Start is called before the first frame update
    void Start()
    {
        emptyCells = new Queue<honeyCell>();
        pollinatedBees = new Queue<workerBee>();
    }

    // Update is called once per frame
    void Update()
    {
        while (pollinatedBees.Count > 0 && emptyCells.Count > 0)
        {
            workerBee bee = pollinatedBees.Dequeue();
            honeyCell cell = emptyCells.Dequeue();
            bee.targetEmptyCell(cell);
        }
    }
}
