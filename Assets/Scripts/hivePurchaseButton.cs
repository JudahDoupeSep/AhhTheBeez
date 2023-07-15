using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public Vector3[] newHivePositions;

    private int nextPosition = 0;

    private void OnMouseDown()
    {
        // TODO: spend honey
        Instantiate(hive, transform.position, Quaternion.identity);
        // TODO: make this button invisible until we have enough honey to purchase?
        if (nextPosition < newHivePositions.Length)
        {
            transform.position = newHivePositions[nextPosition];
            nextPosition++;
        }
    }
}
