using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCookedFish : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer fish; // Use this so as the object cooks, it's going to change color
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        fish = GetComponent<MeshRenderer>();
        //StartCoroutine(cookTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        GetComponent<Transform>().position = new Vector3(gameFlow.plateXpos, 0.1f, 0f);
        foodValue = 1000;
        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
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
