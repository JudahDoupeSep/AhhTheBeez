using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public GameObject queenBeePurchaseButton;
    public GameObject priceInfo;

    private honeyCounter totalHoney;
    private hiveManager hiveManager;
    public PriceDisplay priceDisplay;
    public AudioClip Honey_Important;

    public int price;
    private float scale = 0.75f;
    private int basePrice = 30;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
        hiveManager = controller.GetComponent<hiveManager>();
        hiveManager.hives.Enqueue(gameObject);
        gameObject.SetActive(false);
        price = (int)(hiveManager.hives.Count * basePrice * scale);
        priceDisplay.UpdatePrice(price);
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney >= price)
        {
            totalHoney.totalHoney -= price;
            Instantiate(hive, transform.position, Quaternion.identity);
            hiveManager.popNextHiveButton();
            Destroy(gameObject);
            audioManager.PlaySound(Honey_Important);
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
