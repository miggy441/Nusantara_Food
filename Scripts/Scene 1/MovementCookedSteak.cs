using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCookedSteak : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer steak; // Use this so as the object cooks, it's going to change color
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        steak = GetComponent<MeshRenderer>();
        //StartCoroutine(cookTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        GetComponent<Transform>().position = new Vector3(gameFlow.plateXpos, 0.1f, 0f);
        foodValue = 10000;
        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        Debug.Log(gameFlow.plateValue + " " + gameFlow.orderValue);
        //gameFlow.plateValue += foodValue;
        //stillCooking = "n";
    }

    /*IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(10);
        foodValue = 1000;
        if (stillCooking == "y")
            drumStick.material.color = new Color(.3f, .3f, .3f);
    }*/
}
