using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeTrafficController : MonoBehaviour
{
    public Queue<honeyCell> emptyCells = new Queue<honeyCell>();
    public Queue<workerBee> pollinatedBees = new Queue<workerBee>();

    // Start is called before the first frame update
    void Start()
    {

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
