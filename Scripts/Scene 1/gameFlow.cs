using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameFlow : MonoBehaviour
{
    public static int [] orderValue= { 11000, 11100, 10011 }; 
                                        

    public static int [] plateValue = { 0, 0, 0 }; // This is the plate you're assembling

    public static float [] orderTimer = { 60, 60, 60 };

    public static int plateNum = 0;
    public static int plateXpos = 0;

    //Have to Match plateValue to the orderValue

    public Transform plateSelector;

    public MeshRenderer[] currentPic; // refereing to the plane
    public Texture[] orderPics; // the menu that is ordered

    public static float emptyPlateNow = -1; // This does 2 Things: First, it commands to remove the plate because it's been served.
                                            // Second, to determine which plate to be emptied
                                            // if its negative 1, then delete the plate, but if not, it doesnt delete the plate

    public static float totalCash = 0; // The money you get after completing the order



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < plateValue.Length; i++)
        {
            plateValue[i] = 0;
        }

        for (int rep = 0; rep < 3; rep +=1) // rep is the indicator to which plate that is being used
        {
            if (orderValue[rep] == 11000)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[0]; // order value = 10000 , current pic = 0

            if (orderValue[rep] == 11100)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[1]; // order value  = 1000 , current pic = 1

            if (orderValue[rep] == 10011)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[2]; // order value  = 1 , current pic = 2
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("tab"))
        {
            plateNum += 1;
            plateXpos += 1;

            if (plateNum > 2)
            {
                plateNum = 0;
                plateXpos = 0;
            }
        }

        orderTimer[0] -= Time.deltaTime;
        orderTimer[0] -= Time.deltaTime;
        orderTimer[0] -= Time.deltaTime;

        plateSelector.transform.position = new Vector3(plateXpos, 0.31f, 0);

    }

}
