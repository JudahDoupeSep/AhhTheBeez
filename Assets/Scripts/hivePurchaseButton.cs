using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public GameObject queenBeePurchaseButton;
    public Vector3[] newHivePositions;
    public int cost = 30;

    private honeyCounter totalHoney;
    private int nextPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalHoney = GameObject.FindGameObjectWithTag("HiveMind").GetComponent<honeyCounter>();
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney >= cost)
        {
            totalHoney.totalHoney -= cost;
            GameObject newHive = Instantiate(hive, transform.position, Quaternion.identity);
            GameObject newQueenBeeButton = Instantiate(queenBeePurchaseButton, transform.position, Quaternion.identity);
            newQueenBeeButton.GetComponent<queenBeePurchase>().hive = newHive;
            // TODO: make this button invisible until we have enough honey to purchase?
            if (nextPosition < newHivePositions.Length)
            {
                transform.position = newHivePositions[nextPosition];
                nextPosition++;
            }
        }
    }
}
