using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class queenBeePurchase : MonoBehaviour
{
    public GameObject queenBee;
    public GameObject hive;
    private honeyCounter totalHoney;

    public int price = 5;

    private GameObject priceDisplay;
    public GameObject priceInfo;

    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney > price)
        {
            totalHoney.totalHoney -= price;
            GameObject newQueen = Instantiate(queenBee, transform.position, Quaternion.identity);
            newQueen.GetComponent<queenBee>().setHive(hive);
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        priceDisplay = Instantiate(priceInfo, transform.position, Quaternion.identity);
        priceDisplay.GetComponentInChildren<TextMeshPro>().text = price.ToString();
    }

    private void OnMouseExit()
    {
        Destroy(priceDisplay);
    }
}
