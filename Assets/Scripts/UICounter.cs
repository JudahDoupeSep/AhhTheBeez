using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    
public class UICounter : MonoBehaviour
{
    public honeyCounter totalHoney;
    public TextMeshProUGUI m_textMeshPro;

    void Update()
    {
        m_textMeshPro.SetText(totalHoney.totalHoney.ToString());
    }
}
