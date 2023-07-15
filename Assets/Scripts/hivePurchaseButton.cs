using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public GameObject queenBeePurchaseButton;
    public GameObject priceInfo;
    public Vector3[] newHivePositions;
    public int price = 30;

    private honeyCounter totalHoney;
    private int nextPosition = 0;
    private GameObject priceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        totalHoney = GameObject.FindGameObjectWithTag("HiveMind").GetComponent<honeyCounter>();
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney >= price)
        {
            totalHoney.totalHoney -= price;
            Instantiate(hive, transform.position, Quaternion.identity);
            // TODO: make this button invisible until we have enough honey to purchase?
            if (nextPosition < newHivePositions.Length)
            {
                transform.position = newHivePositions[nextPosition];
                nextPosition++;
            }
        }
    }

    private void OnMouseEnter()
    {
        priceDisplay = Instantiate(priceInfo, transform.position, Quaternion.identity);
        priceDisplay.GetComponentInChildren<TextMeshPro>().text = price.ToString();
    }

    private void OnMouseExit()
    {
        DestroyImmediate(priceDisplay);
    }
}
