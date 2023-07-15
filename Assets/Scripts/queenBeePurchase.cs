using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBeePurchase : MonoBehaviour
{
    public GameObject queenBee;
    public GameObject hive;
    private honeyCounter totalHoney;

    public int price = 5;

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

    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
    }
}
