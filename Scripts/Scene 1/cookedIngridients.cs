using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedIngridients : MonoBehaviour
{
    //public Transform cloneObject;
    public int foodValue;

    [Header("Chicken")]
    public GameObject rawChicken;
    public GameObject cookedChicken;
    private GameObject rawChickenClone;

    [Header("Steak")]
    public GameObject rawSteak;
    public GameObject cookedSteak;
    private GameObject rawSteakClone;

    [Header("Fish")]
    public GameObject rawFish;
    public GameObject cookedFish;
    private GameObject rawFishClone;


    // Start is called before the first frame update
    void Start()
    {
        
        cookedChicken.SetActive(false);

        
        cookedSteak.SetActive(false);

        
        cookedFish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "DrumstickRaw")
        //Instantiate(cloneObject, new Vector3(0.5f, 0.05f, -0.333f), cloneObject.rotation);
        //Instantiate(cookedChicken, new Vector3(0.5f, 0.05f, -0.333f), cookedChicken.rotation);
        {
            rawChickenClone = Instantiate(rawChicken, new Vector3(3.1f, 0.4f, -0.3f), Quaternion.identity);
            StartCoroutine(cookingTimeChicken());
        }

        if (gameObject.name == "Steak")
        {
            rawSteakClone = Instantiate(rawSteak, new Vector3(3.1f, 0.4f, -0.3f), Quaternion.identity);
            StartCoroutine(cookingTimeSteak());
        }

        if (gameObject.name == "FishFillet")
        {
            rawFishClone = Instantiate(rawFish, new Vector3(3.1f, 0.4f, -0.3f), Quaternion.identity);
            StartCoroutine(cookingTimeFish());
        }

        //gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        //Debug.Log(gameFlow.plateValue + " " + gameFlow.orderValue);
    }


    IEnumerator cookingTimeChicken()
    {
        yield return new WaitForSeconds(5);
        //Instantiate(cookedChicken, new Vector3(3.1f, 0.4f, -0.3f));
        cookedChicken.transform.position = new Vector3(3.1f, 0.4f, -0.3f);
        cookedChicken.SetActive(true);
        Destroy(rawChickenClone);
    }

    IEnumerator cookingTimeSteak()
    {
        yield return new WaitForSeconds(5);
        cookedSteak.transform.position = new Vector3(3.1f, 0.4f, -0.3f);
        cookedSteak.SetActive(true);
        Destroy(rawSteakClone);
    }

    IEnumerator cookingTimeFish()
    {
        yield return new WaitForSeconds(5);
        cookedFish.transform.position = new Vector3(3.109f, 0.336f, -0.243f);
        cookedFish.SetActive(true);
        Destroy(rawFishClone);
    }






}
