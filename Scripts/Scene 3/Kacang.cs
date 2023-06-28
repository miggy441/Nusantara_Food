using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kacang : MonoBehaviour
{
    public Transform saosKacang;
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
        if (gameObject.name == "wadah1")

            Instantiate(saosKacang, new Vector3(Gameflow3.plateXpos, 0.3f, -0.009f), saosKacang.rotation);
            SFXManager.instance.UIClick();


        Gameflow3.plateValue[Gameflow3.plateNum] += foodValue;
        Debug.Log(Gameflow3.plateValue + " " + Gameflow3.orderValue);
    }
}
