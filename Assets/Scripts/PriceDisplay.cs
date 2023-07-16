using TMPro;
using UnityEngine;

public class PriceDisplay : MonoBehaviour
{
    public TextMeshPro NameText; 
    public TextMeshPro PriceText;
    public float Padding;

    public void UpdatePrice(int newPrice)
    {
        PriceText.text = $"Price: {newPrice}";
    }
    
    public void UpdateItemName(string newName)
    {
        NameText.text = newName;
    }

    public void ShowName()
    {
        NameText.gameObject.SetActive(true);
    }
    
    public void HideName()
    {
        NameText.gameObject.SetActive(false);
    }

    void Start()
    {
        HideName();
    }
    
    void Update()
    {
        UpdateBackground();
    }

    void UpdateBackground()
    {
        var sprite = GetComponent<SpriteRenderer>();
        var rect = GetComponent<RectTransform>().rect;
        sprite.size = new Vector2(rect.width + Padding, rect.height + Padding);
    }
}
