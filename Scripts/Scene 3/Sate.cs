using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sate : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer sate;
    private string stillCooking = "y";
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        sate = GetComponent<MeshRenderer>();
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
        GetComponent<Transform>().position = new Vector3(Gameflow3.plateXpos, 0.351f, -0.006f);
        Gameflow3.plateValue[Gameflow3.plateNum] += foodValue;
        stillCooking = "n";
    }

    IEnumerator cookTimer()
    {
        SFXManager.instance.GrillSFX();
        yield return new WaitForSeconds(5);
        foodValue = 10000;
        if (stillCooking == "y")
            sate.material.color = new Color(0.9063317f, 0.3463884f, 0.3001801f);
    }

    IEnumerator smoke()
    {
        yield return new WaitForSeconds(5);
        particle.Stop();
    }
}
