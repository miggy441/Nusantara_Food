using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaksoSpawn : MonoBehaviour
{
    public Transform cloneObj;

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
        if (gameObject.name == "Bakso")
        {
            Instantiate(cloneObj, new Vector3(3f, 1f, -0.34f), cloneObj.rotation);
            SFXManager.instance.UIClick();

        }


    }
}
