﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour {

    public float MoveSpeed = 10;
    public float TurnSpeed = 60;

    public float TurnModifier = 1;
    bool UseTurnModifier = false;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            UseTurnModifier = true;
        else
            UseTurnModifier = false;

        float hMove = 0.0F;

        if (UseTurnModifier)
            hMove = Input.GetAxis("Horizontal") * (TurnSpeed * TurnModifier) * Time.deltaTime;
        else
            hMove = Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime;

        float vMove = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        //transform.Rotate(0, hMove, 0);
        //transform.Translate(0, 0, vMove);
        gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0, hMove, 0);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, vMove);
	}

    void OnCollisionEnter(Collision collision)
    {

    }
}
