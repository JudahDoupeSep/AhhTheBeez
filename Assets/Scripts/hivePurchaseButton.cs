using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hivePurchaseButton : MonoBehaviour
{
    public GameObject hive;
    public Vector3[] newHivePositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        // TODO: spend honey
        Instantiate(hive, transform.position, Quaternion.identity);
        // TODO: make invisible
        // TODO: move to next hive position
    }
}
