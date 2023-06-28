using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCookMove : MonoBehaviour
{
    private int foodValue = 0;
    public MeshRenderer drumStick;
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        drumStick = GetComponent<MeshRenderer>();
        StartCoroutine(cookTimer());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        GetComponent<Transform>().position = new Vector3(gameFlow.plateXpos, 0.1f, 0f);
        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(3);
        foodValue = 1;
        if (stillCooking == "y")
            drumStick.material.color = new Color(0.5699129f, 0.3153827f, 0.2411447f);

    }
}
