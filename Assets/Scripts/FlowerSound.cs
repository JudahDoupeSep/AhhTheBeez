using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSound : MonoBehaviour
{
    public AudioClip randomClip;

     private void OnMouseDown(){
         audioManager.PlaySound(randomClip);
     }
}
