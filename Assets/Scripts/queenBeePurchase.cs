using UnityEngine;

public class queenBeePurchase : MonoBehaviour
{
    public GameObject queenBee;
    public GameObject hive;
    private honeyCounter totalHoney;
    public AudioClip Jazz;
    public int price = 5;
    private hiveManager hiveManager;

    public int price = 0;
    private readonly int basePrice = 10;
    private readonly float scale = 0.75f;

    public PriceDisplay priceDisplay;

    void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("HiveMind");
        totalHoney = controller.GetComponent<honeyCounter>();
        hiveManager = controller.GetComponent<hiveManager>();
        price = hiveManager.hiveCount != 1 ? (int)(basePrice * hiveManager.hiveCount * scale) : basePrice;
        priceDisplay.UpdatePrice(price);
    }

    private void OnMouseDown()
    {
        if (totalHoney.totalHoney > price)
        {
            totalHoney.totalHoney -= price;
            GameObject newQueen = Instantiate(queenBee, transform.position, Quaternion.identity);
            newQueen.GetComponent<queenBee>().setHive(hive);
            Destroy(gameObject);
            audioManager.PlaySound(Jazz);
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
