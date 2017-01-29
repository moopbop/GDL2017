using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float forwardCheckDistance = 5f;
    public float groundCheckDistance = 5f;
    public GameObject pedestrian;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!CheckFloorContact())
            TurnAround();

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

    bool CheckAheadCollision()
    {
        return Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            forwardCheckDistance);
    }

    void TurnAround()
    {
        float turn = Random.Range(120, 190);
        transform.Rotate(0, turn, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BuildWorld>() != null)
        {
            Vector3 tempPedestrianPosition;

            BuildWorld world = other.GetComponent<BuildWorld>();

            do
            {
                tempPedestrianPosition = new Vector3(Random.Range(0, world.worldX - world.gridSize), 1, Random.Range(0, world.worldX - world.gridSize));
            } while (Physics.OverlapBox(tempPedestrianPosition, this.transform.position / 2).Length != 0);

            Instantiate(pedestrian, tempPedestrianPosition, new Quaternion());

            Destroy(this.gameObject);

        }
    }
}