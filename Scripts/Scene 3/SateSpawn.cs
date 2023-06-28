using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateSpawn : MonoBehaviour
{
    public static SateSpawn instance;

    public Transform cloneObj;
    public float plateXpos = 3.1f;
    public Transform plateSelector;

    // Start is called before the first frame update
    void Start()
    {
        plateSelector.transform.position = new Vector3(plateXpos, 0.8f, -0.2f);
        MeatCon.nilai = plateXpos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("caps lock"))
        {
            plateXpos += 0.4f;

            if (plateXpos > 4.2f)
            {
                plateXpos = 3.1f;
            }
            plateSelector.transform.position = new Vector3(plateXpos, 0.8f, -0.2f);
            MeatCon.nilai = plateXpos;
        }
        
    }
    //private void OnMouseDown()
    //{
    //    if (gameObject.name == "Sate")
    //    {
    //        Instantiate(cloneObj, new Vector3(plateXpos, 0.8302054F, -0.2476368f), cloneObj.rotation);

    //    }
    //}
}
