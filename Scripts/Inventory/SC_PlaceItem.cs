using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlaceItem : MonoBehaviour
{
    public string itemName = "Some Item"; //Each item must have an unique name

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "PlaceItem";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
