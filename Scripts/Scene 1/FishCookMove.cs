using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCookMove : MonoBehaviour
{
    private int foodValue = 0;
    public MeshRenderer fish;
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        fish = GetComponent<MeshRenderer>();
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
        foodValue = 1000;
        if (stillCooking == "y")
            fish.material.color = new Color(0.8199652f, 0.6773438f, 0.6193065f);

    }
}
