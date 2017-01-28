using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float moveSpeed = 100f;
    public float turnSpeed = 40f;
    public Vector3 centerOfMass;

    public float turnModifier = 1.5f;

    public GameObject Pilot;


    bool useTurnModifier = false;
    float hMove = 0.0f;
    float vMove = 0.0f;
    Quaternion initialRotation;
    Vector3 initialPosition;

	// Use this for initialization
	void Start () {
        initialRotation = gameObject.transform.rotation;
        initialPosition = gameObject.transform.position;
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
	}

    void ResetPosition()
    {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = initialRotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            useTurnModifier = true;
        else
            useTurnModifier = false;

        if (Input.GetKeyUp(KeyCode.R))
            ResetPosition();

        if (useTurnModifier)
            hMove = Input.GetAxis("turn") * (turnSpeed * turnModifier) * Time.deltaTime;
        else
            hMove = Input.GetAxis("turn") * turnSpeed * Time.deltaTime;

        vMove = Input.GetAxis("hInput") * moveSpeed * Time.deltaTime;

        
    }

    void FixedUpdate()
    {
        if (vMove < 0)
            gameObject.GetComponent<Rigidbody>().AddTorque(0, -hMove, 0);
        else
            gameObject.GetComponent<Rigidbody>().AddTorque(0, hMove, 0);

        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, vMove);
    }
}
