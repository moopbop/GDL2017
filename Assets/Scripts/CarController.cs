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
    public float gravityActivateThreshold;
    public float acclNoGravLerp;
    public float turnNoGravLerp;
    public GameObject Pilot;
    public float gravityActivateTimeThreshold;

    float moveSpeed;
    float turnSpeed;
    bool useTurnModifier;
    float hMove = 0.0f;
    float vMove = 0.0f;
    Quaternion initialRotation;
    Vector3 initialPosition;
    bool useGravity;
    Ray gravityCheckRay;
    float origMoveSpeed;
    float origTurnSpeed;
    float gravityTime;

	// Use this for initialization
	void Start () {
        useTurnModifier = false;
        useGravity = true;
        initialRotation = gameObject.transform.rotation;
        initialPosition = gameObject.transform.position;
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        moveSpeed = GetComponent<Rigidbody>().mass * 5000;
        turnSpeed = GetComponent<Rigidbody>().mass * 2500;

        origMoveSpeed = moveSpeed;
        origTurnSpeed = turnSpeed;  
	}

    void ResetPosition()
    {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = initialRotation;
    }
	
	// Update is called once per frame
	void Update () {

        // Capture turn modifier key.
        if (Input.GetKey(KeyCode.LeftShift))
            useTurnModifier = true;
        else
            useTurnModifier = false;

        // Capture reset position key
        if (Input.GetKeyUp(KeyCode.R))
            ResetPosition();

        // Check for gravity activation.
        if (Physics.Raycast(
            transform.position,                         // Raycast start position
            transform.TransformDirection(Vector3.down), // Raycast direction
            gravityActivateThreshold))                  // Raycast length
        {
            useGravity = false;
            gravityTime = 0.0f;
        }
        else
        {
            useGravity = true;
            gravityTime += Time.deltaTime;
        }

        if (useGravity && gravityTime >= gravityActivateTimeThreshold)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, acclNoGravLerp);
            turnSpeed = Mathf.Lerp(turnSpeed, 0, turnNoGravLerp);
        }
        else
        {
            turnSpeed = origTurnSpeed;
            moveSpeed = origMoveSpeed;
        }

        // Calculate values to use for physics calculation in FixedUpdate
        if (useTurnModifier)
            hMove = Input.GetAxis("turn") * (turnSpeed * turnModifier) * Time.deltaTime;
        else
            hMove = Input.GetAxis("turn") * turnSpeed * Time.deltaTime;

        vMove = Input.GetAxis("hInput") * moveSpeed * Time.deltaTime;

        Debug.Log(useGravity);
    }

    void FixedUpdate()
    {
        //if (useGravity)
        //{
        //    vMove = Mathf.Lerp(vMove, 0, turnNoGravLerp);
        //}

        if (vMove < 0)
            gameObject.GetComponent<Rigidbody>().AddTorque(0, -hMove, 0);
        else
            gameObject.GetComponent<Rigidbody>().AddTorque(0, hMove, 0);

        Vector3 force = new Vector3();
        if (useGravity && gravityTime >= gravityActivateTimeThreshold)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, -gravity, 0);
            //hMove = Mathf.Lerp(hMove, 0, acclNoGravLerp);
        }

        force.z = hMove;

        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, vMove));
    }
}
