using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseMove : MonoBehaviour
{
    public Transform cheese;
    public int foodValue;
    private string stillCooking = "y";

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
        if (gameObject.name == "keju")

            Instantiate(cheese, new Vector3(gameFlow.plateXpos, 0.5f, 0f), cheese.rotation);
            SFXManager.instance.UIClick();


        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        Debug.Log(gameFlow.plateValue + " " + gameFlow.orderValue);
    }

}
