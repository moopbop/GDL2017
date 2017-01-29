using System.Collections;
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
            RotateRandomY();

        if (!CheckAheadCollision())
        {
            Vector3 move = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
            transform.Translate(move);
        }
	}

    bool CheckAheadCollision()
    {
        return Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            forwardCheckDistance);
    }

    void RotateRandomY()
    {
        float turn = Random.Range(0, 60);
        transform.Rotate(0, turn, 0);
    }

    bool CheckFloorContact()
    {
        // Check each corner of pedestrian, and middle

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