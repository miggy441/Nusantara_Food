using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Handler : MonoBehaviour
{
    private float SFXVol = 1f;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = SFXVol;
    }

    public void updateVol(float volume)
    {
        SFXVol = volume;
    }
}
