using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Text text = this.GetComponent<Text>();

        text.text = "Hmm, this coffee is pretty OK. You're still a bitch, though. During your travels you killed " + GameObject.Find("World").GetComponent<BuildWorld>().killed.ToString() + "people.That's coming out of your check.";

    }
}
