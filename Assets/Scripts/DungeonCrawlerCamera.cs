using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerCamera : MonoBehaviour {

    public GameObject Target;
    Vector3 Offset;
    public float Damping = 1;

	// Use this for initialization
	void Start () {
        Offset = transform.position - Target.transform.position;
	}
	
	void LateUpdate () {
        Vector3 desiredPosition = Target.transform.position + Offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * Damping);
        transform.position = position;
        transform.LookAt(Target.transform.position);
        
        
	}
}
