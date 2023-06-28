using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCookedMove : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer egg;
    private string stillCooking = "y";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        egg = GetComponent<MeshRenderer>();
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
        GetComponent<Transform>().position = new Vector3(gameFlow.plateXpos, 0.6f, 0f);
        gameFlow.plateValue[gameFlow.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        SFXManager.instance.cookEggSFX();
        yield return new WaitForSeconds(5);
        foodValue = 1000;
        if (stillCooking == "y")
            egg.material.color = new Color(1f, 0.3920045f, 0f);

    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }
}
