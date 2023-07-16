using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static void PlaySound(AudioClip audioClip){
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        //Destroy(audioSource);
    }
}
