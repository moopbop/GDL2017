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

    bool coffee = false;

    public Material white;
    public Material colored;
    public GameObject coffeeObj;

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
            hMove = Input.GetAxis("turn") * (turnSpeed * turnModifier) * Time.deltaTime;
        else
            hMove = Input.GetAxis("turn") * turnSpeed * Time.deltaTime;

        vMove = Input.GetAxis("hInput") * moveSpeed * Time.deltaTime;
	}

    void FixedUpdate()
    {
        if (vMove < 0)
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0, -hMove, 0);
        else
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0, hMove, 0);
      
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, vMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent("Coffee") != null)
        {
            Destroy(collision.gameObject);
            coffee = true;
            this.GetComponent<Renderer>().material = white;
        }
        else if(collision.gameObject.GetComponent<CarController>() != null)
        {
            
            CarController car = collision.gameObject.GetComponent<CarController>();
            if (car.Pilot != null && this.coffee == true)
            {
                this.coffee = false;
                this.GetComponent<Renderer>().material = colored;

                Vector3 tempCoffeePosition;

                do
                {
                    tempCoffeePosition = new Vector3(Random.Range(-25, 25) + this.transform.position.x, 0, Random.Range(-25, 25) + this.transform.position.z);
                } while (Physics.OverlapBox(tempCoffeePosition, coffeeObj.transform.position/2).Length != 0);
                

                Instantiate(coffeeObj, tempCoffeePosition, new Quaternion());
            }
        }
    }
}
