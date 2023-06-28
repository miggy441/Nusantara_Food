using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leek : MonoBehaviour
{
    public Transform leek;
    public int foodValue;

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
        if (gameObject.name == "daun")

            Instantiate(leek, new Vector3(GameFlow2.plateXpos, 0.482f, 0.012f), leek.rotation);
            SFXManager.instance.UIClick();


        GameFlow2.plateValue[GameFlow2.plateNum] += foodValue;
        Debug.Log(GameFlow2.plateValue + " " + GameFlow2.orderValue);
    }
}
