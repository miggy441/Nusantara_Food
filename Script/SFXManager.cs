using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    public AudioClip uibutton;
    public AudioClip CookEgg;
    public AudioClip boil;
    public AudioClip grilling;

    private AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
            instance = this;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIClick()
    {
        GetComponent<AudioSource>().PlayOneShot(uibutton);
    }

    public void BoilSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(boil);
    }

    public void GrillSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(grilling);
    }

    public void cookEggSFX()
    {
        audio.PlayOneShot(CookEgg);
    }
}
