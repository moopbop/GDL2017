using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioMixerSnapshot lowTime;
    public AudioMixerSnapshot climax;
    public AudioMixerSnapshot buildup;
    public float bpm = 106;

    private float fadeTime;
    private float quarterNote;
    private float fastFadeTime;

	// Use this for initialization
	void Start () {
        quarterNote = 60 / bpm;
        fadeTime = quarterNote;
        //fastFadeTime = quarterNote;

        lowTime.TransitionTo(0);
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buildup.TransitionTo(fadeTime);
        }
        else if (other.CompareTag("Car") && other.gameObject.GetComponent<CarController>().Pilot != null)
        {
            buildup.TransitionTo(fadeTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lowTime.TransitionTo(fadeTime);
        }
        else if (other.CompareTag("Car") && other.gameObject.GetComponent<CarController>().Pilot != null)
        {
            lowTime.TransitionTo(fadeTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            climax.TransitionTo(0);
        }
    }

    public void ToLowTime()
    {
        lowTime.TransitionTo(fadeTime);
    }
}
