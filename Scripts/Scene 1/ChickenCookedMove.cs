using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCookedMove : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer chicken;
    private string stillCooking = "y";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        chicken = GetComponent<MeshRenderer>();
        StartCoroutine(cookTimer());
        particle.Play();
        StartCoroutine(smoke());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        SFXManager.instance.UIClick();
        GetComponent<Transform>().position = new Vector3(gameFlow.plateXpos, 0.5f, 0f);
        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        SFXManager.instance.GrillSFX();
        yield return new WaitForSeconds(5);
        foodValue = 1;
        if (stillCooking == "y")
            chicken.material.color = new Color(0.5699129f, 0.3153827f, 0.2411447f);

    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }
}
