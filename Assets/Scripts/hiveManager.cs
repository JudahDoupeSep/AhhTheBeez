using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiveManager : MonoBehaviour
{
    public Queue<GameObject> hives = new Queue<GameObject>();
    public int hiveCount = 1;
    private GameObject currentAvailableButton;

    // Update is called once per frame
    void Update()
    {
        if (currentAvailableButton == null)
        {
            popNextHiveButton();
        }
    }

    public void popNextHiveButton()
    {
        if (hives.Count > 0)
        {
            GameObject newHiveButton = hives.Dequeue();
            hiveCount++;
            currentAvailableButton = newHiveButton;
            newHiveButton.SetActive(true);
        }
    }
}
