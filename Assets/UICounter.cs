using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

    
    public class UICounter : MonoBehaviour
    {

        public honeyCounter totalHoney;

        public TextMeshProUGUI m_textMeshPro;
        //private TMP_FontAsset m_FontAsset;

        private const string label = "";
        private float m_frame;


        void Start()
        {
    
        }


        void Update()
        {
            m_textMeshPro.SetText(totalHoney.totalHoney.ToString(), m_frame % 1000);
            m_frame += 1 * Time.deltaTime;
        }

    }

