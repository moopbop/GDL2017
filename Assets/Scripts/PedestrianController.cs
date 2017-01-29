<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float forwardCheckDistance = 5f;
    public float groundCheckDistance = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!CheckFloorContact())
            return;

        if (!CheckAheadCollision())
        {
            Vector3 move = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
            transform.Translate(move);
        }

        Debug.Log(CheckFloorContact());
	}

    bool CheckAheadCollision()
    {
        return Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            forwardCheckDistance);
    }

    bool CheckFloorContact()
    {
        Vector3 nextLocation = transform.position;
        nextLocation.z = nextLocation.z + ((moveSpeed + 0.5f) * Time.deltaTime);

        RaycastHit hit = new RaycastHit();

        bool objectBelow = Physics.Raycast(
            nextLocation,   // Origin
            Vector3.down,   // Direction
            out hit,    // out RaycastHit
            groundCheckDistance,    // MaxDistance
            3,  // Tag (3 is empty, ignores tag)
            QueryTriggerInteraction.Ignore);    // Ignore colliders marked as "trigger".

        return (objectBelow && hit.transform.gameObject.tag == "Floor");
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float forwardCheckDistance = 5f;
    public float groundCheckDistance = 5f;
    public float randomRotMax = 90;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!CheckFloorContact())
        {
            transform.Rotate(0, 180, 0);
        }

        if (!CheckAheadCollision())
        {
            Vector3 move = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
            transform.Translate(move);
        }
        else
        {
            RotateRandomY();
        }
	}

    void RotateRandomY()
    {
        float yRot = Random.Range(0, randomRotMax) * Time.deltaTime;

        transform.Rotate(0, yRot, 0);
    }

    bool CheckAheadCollision()
    {
        return Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            forwardCheckDistance);
    }

    bool CheckFloorContact()
    {
        Vector3 nextLocation = transform.position;
        nextLocation.z = nextLocation.z + ((moveSpeed + 0.5f) * Time.deltaTime);

        RaycastHit hit = new RaycastHit();

        bool objectBelow = Physics.Raycast(
            nextLocation,   // Origin
            Vector3.down,   // Direction
            out hit,    // out RaycastHit
            groundCheckDistance,    // MaxDistance
            3,  // Tag (3 is empty, ignores tag)
            QueryTriggerInteraction.Ignore);    // Ignore colliders marked as "trigger".

        return (objectBelow && hit.transform.gameObject.tag == "Floor");
    }
}
>>>>>>> crowds
