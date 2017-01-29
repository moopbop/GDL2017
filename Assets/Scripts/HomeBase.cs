using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour {

    public GameObject myPlayer;

	// Use this for initialization
	void Start () {
        this.myPlayer = GameObject.Find("Player");
		this.GetComponent<Renderer>().material = myPlayer.GetComponent<Renderer>().material;
    }
}
