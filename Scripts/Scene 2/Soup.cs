using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : MonoBehaviour
{
    public Transform soup;
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
        if (gameObject.name == "panci")

            Instantiate(soup, new Vector3(GameFlow2.plateXpos, 0.48f, -0.09f), soup.rotation);
            SFXManager.instance.UIClick();


        GameFlow2.plateValue[GameFlow2.plateNum] += foodValue;
        Debug.Log(GameFlow2.plateValue + " " + GameFlow2.orderValue);
    }
}
