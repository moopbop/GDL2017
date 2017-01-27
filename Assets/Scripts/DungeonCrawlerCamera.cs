using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerCamera : MonoBehaviour {

    public GameObject Target;
    Vector3 offset;
    public float Damping = 1f;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        offset = transform.position - Target.transform.position;
	}
	
	void LateUpdate () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        transform.position = Target.transform.position + offset;
        transform.LookAt(Target.transform.position);
        //Vector3 desiredPosition = Target.transform.position + Offset;
        //Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * Damping);
        //transform.position = position;
        //transform.LookAt(Target.transform.position);
        //if (Input.GetMouseButton(1))
        //{
            //transform.RotateAround(Target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
            //transform.RotateAround(Target.transform.position, Vector3.right, -Input.GetAxis("Mouse Y") * speed);

        //}
        
	}
}
