using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public GameObject queenBeePurchaseButton;
    public GameObject priceInfo;
    public int price = 30;

    private honeyCounter totalHoney;
    private hiveManager hiveManager;
    public PriceDisplay priceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
        hiveManager = controller.GetComponent<hiveManager>();
        hiveManager.hives.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney >= price)
        {
            totalHoney.totalHoney -= price;
            Instantiate(hive, transform.position, Quaternion.identity);
            hiveManager.popNextHiveButton();
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        priceDisplay.ShowName();
    }

    private void OnMouseExit()
    {
        priceDisplay.HideName();
    }
}
