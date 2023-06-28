using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPlace : MonoBehaviour
{
    public Transform cloneObject; // Creating a reference to the instantiated version
    public int foodValue; // this value gets added to the plate value and then will be compared to the order value

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
        if (gameObject.name == "Steak")
        
            Instantiate(cloneObject, new Vector3(-0.891f, 1.063f, -1.086f), cloneObject.rotation);
        
        if (gameObject.name == "FishFillet")

            Instantiate(cloneObject, new Vector3(-0.131f, 0.022f, 0.068f), cloneObject.rotation);


        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        Debug.Log(gameFlow.plateValue+" "+gameFlow.orderValue);
    }
}
