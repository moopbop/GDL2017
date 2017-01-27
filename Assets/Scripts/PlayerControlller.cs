using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour {

    public float MoveSpeed = 10;
    public float TurnSpeed = 60;

    float TurnModifier = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            TurnModifier = 2;
        else
            TurnModifier = 1;

        float hMove = Input.GetAxis("Horizontal") * (TurnSpeed * TurnModifier) * Time.deltaTime;
        float vMove = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        transform.Rotate(0, hMove, 0);
        transform.Translate(0, 0, vMove);
	}
}
