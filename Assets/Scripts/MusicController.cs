using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioMixerSnapshot lowTime;
    public AudioMixerSnapshot climax;
    public AudioMixerSnapshot buildup;
    public float bpm = 108;

    private float fadeTime;
    private float quarterNote;

	// Use this for initialization
	void Start () {
        quarterNote = 60 / bpm;
        fadeTime = quarterNote * 2;
	}


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buildup.TransitionTo(fadeTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lowTime.TransitionTo(fadeTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            climax.TransitionTo(fadeTime);
        }
    }

    public void ToLowTime()
    {
        lowTime.TransitionTo(fadeTime);
    }
}
