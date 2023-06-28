using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakso : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer bakso;
    private string stillCooking = "y";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        bakso = GetComponent<MeshRenderer>();
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
        GetComponent<Transform>().position = new Vector3(GameFlow2.plateXpos, 0.9f, -0.065f);
        GameFlow2.plateValue[GameFlow2.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        SFXManager.instance.BoilSFX();
        yield return new WaitForSeconds(5);
        foodValue = 10000;
        if (stillCooking == "y")
            bakso.material.color = new Color(1f, 0.3920045f, 0f);

    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }

}
