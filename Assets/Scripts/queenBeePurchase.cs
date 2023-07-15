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

        priceDisplay = Instantiate(priceInfo, transform.position, Quaternion.identity);
        priceDisplay.GetComponentInChildren<TextMeshPro>().text = string.Format("Buy Queen Bee: {0}", price.ToString());
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney > price)
        {
            totalHoney.totalHoney -= price;
            GameObject newQueen = Instantiate(queenBee, transform.position, Quaternion.identity);
            newQueen.GetComponent<queenBee>().setHive(hive);
            Destroy(gameObject);
            Destroy(priceDisplay);
        }
    }
}
