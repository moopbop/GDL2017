using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour {

    public float moveSpeed = 400f;
    public float turnSpeed = 90f;

    public float turnModifier = 1.5f;
    bool useTurnModifier = false;

    float hMove = 0.0f;
    float vMove = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            useTurnModifier = true;
        else
            useTurnModifier = false;


        if (useTurnModifier)
            hMove = Input.GetAxis("Horizontal") * (turnSpeed * turnModifier) * Time.deltaTime;
        else
            hMove = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        vMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
	}

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0, hMove, 0);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, vMove);
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}
