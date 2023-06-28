using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMove : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer meat;
    public ParticleSystem particle;
    private string stillCooking = "y";

    // Start is called before the first frame update
    void Start()
    {

        meat = GetComponent<MeshRenderer>();
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
        foodValue = 100;
        if (stillCooking == "y")
            meat.material.color = new Color(0.509434f, 0.3123325f, 0.1513884f);

    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }
}
