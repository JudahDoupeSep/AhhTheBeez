using TMPro;
using UnityEngine;

public class PriceDisplay : MonoBehaviour
{
    public TextMeshPro NameText; 
    public TextMeshPro PriceText;
    public float Padding;

    public Color TextColor;
    public Color ErrorColor;
    
    private int _price;
    
    public void UpdatePrice(int newPrice)
    {
        _price = newPrice;
        PriceText.text = $"{newPrice}";
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

    void Update()
    {
        UpdateBackground();
        UpdatePriceText();
    }

    void UpdateBackground()
    {
        var sprite = GetComponent<SpriteRenderer>();
        var rect = GetComponent<RectTransform>().rect;
        sprite.size = new Vector2(rect.width + Padding, rect.height + Padding);
    }

    void UpdatePriceText()
    {
        var color = FindObjectOfType<honeyCounter>().totalHoney < _price
            ? ErrorColor
            : TextColor;
        PriceText.color = color;
        PriceText.text = _price.ToString();
    }
}
