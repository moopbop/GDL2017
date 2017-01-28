using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    //public float moveSpeed = 100f;
    //public float turnSpeed = 40f;
    public Vector3 centerOfMass;
    public float gravity;
    public float turnModifier = 1.5f;
    public float floatDistance = 5;

    public GameObject Pilot;

    float moveSpeed;
    float turnSpeed;
    bool useTurnModifier;
    float hMove = 0.0f;
    float vMove = 0.0f;
    Quaternion initialRotation;
    Vector3 initialPosition;
    bool useGravity;
    Ray gravityCheckRay;

	// Use this for initialization
	void Start () {
        useTurnModifier = false;
        useGravity = true;
        initialRotation = gameObject.transform.rotation;
        initialPosition = gameObject.transform.position;
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        moveSpeed = GetComponent<Rigidbody>().mass * 5000;
        turnSpeed = GetComponent<Rigidbody>().mass * 2500;

        gravityCheckRay.origin = gameObject.transform.position;
        //gravityCheckRay.direction.
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

        Debug.Log(useGravity);
    }

    void FixedUpdate()
    {
        if (vMove < 0)
            gameObject.GetComponent<Rigidbody>().AddTorque(0, -hMove, 0);
        else
            gameObject.GetComponent<Rigidbody>().AddTorque(0, hMove, 0);

        Vector3 force = new Vector3(0, 0, vMove);
        if (useGravity)
            force.y = -gravity;

        gameObject.GetComponent<Rigidbody>().AddRelativeForce(force);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    useGravity = false;
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    useGravity = true;
    //}

    //void OnCollisionStay(Collision collision)
    //{
    //    useGravity = false;
    //}
}
