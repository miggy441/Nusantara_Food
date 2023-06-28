using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCookedMove : MonoBehaviour
{
    private int foodValue = 0;
    public MeshRenderer rice;
    private string stillCooking = "y";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        rice = GetComponent<MeshRenderer>();
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
        SFXManager.instance.GrillSFX();
        yield return new WaitForSeconds(5);
        foodValue = 10000;
        if (stillCooking == "y")
            rice.material.color = new Color(0.6132076f, 0.4466312f, 0.2400765f);

    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }
}
