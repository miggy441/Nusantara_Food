using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCon : MonoBehaviour
{

    public Transform cloneObj;
    public static float nilai;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnMouseDown()
    //{
    //    if (gameObject.name == "Steak")
    //    {
    //        Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
    //    }

    //    if (gameObject.name == "nasi")
    //    {
    //        Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
    //    }

    //    if (gameObject.name == "telur")
    //    {
    //        Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
    //    }

    //    if (gameObject.name == "ayam")
    //    {
    //        Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
    //    }
    //}
    public void Cooking()
    {        
        if (gameObject.name == "Steak")
        {
            Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
        }

        if (gameObject.name == "nasi")
        {
            Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
        }

        if (gameObject.name == "telur")
        {
            Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
        }

        if (gameObject.name == "ayam")
        {
            Instantiate(cloneObj, new Vector3(2.865f, 0.476f, -0.141f), cloneObj.rotation);
        }
        if (gameObject.name == "Sate")
        {
            Instantiate(cloneObj, new Vector3(nilai, 0.8302054F, -0.2476368f), cloneObj.rotation);
        }
        if (gameObject.name == "Bakso")
        {
            Instantiate(cloneObj, new Vector3(3f, 1f, -0.34f), cloneObj.rotation);
        }
    }
}
