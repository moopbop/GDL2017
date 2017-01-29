﻿using System.Collections;
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
    public Camera myCamera;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
            useTurnModifier = true;
        else
            useTurnModifier = false;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            RaycastHit[] temp = Physics.SphereCastAll(this.transform.position, 2f, transform.up);

            for (int i = 0; i < temp.Length; ++i)
            {
                if (temp[i].transform.gameObject.GetComponent<CarController>() != null)
                {
                    if (temp[i].transform.gameObject.GetComponent<CarController>().Pilot == null)
                    {
                        temp[i].transform.gameObject.GetComponent<CarController>().Pilot = this.gameObject;
                        temp[i].transform.gameObject.GetComponent<CarController>().myCamera = this.myCamera;
                        temp[i].transform.gameObject.GetComponent<CarController>().delay = 1;
                        this.myCamera.transform.parent = temp[i].transform;
                        this.myCamera.GetComponent<DungeonCrawlerCamera>().changeTarget(temp[i].transform.gameObject, "Car");
                        this.myCamera = null;
                        this.transform.position = new Vector3(0, -20, 0);
                        this.moveSpeed = 0;
                        this.GetComponent<Rigidbody>().useGravity = false;
                        break;
                    }
                }
            }
        }


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
        else if (collision.gameObject.GetComponent<CarController>() != null)
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
        else if (collision.gameObject.GetComponent<HomeBase>() != null)
        {
            if (collision.gameObject.GetComponent<HomeBase>().myPlayer == this.gameObject && this.coffee == true)
            Debug.Log("You win!!");
        }

    }
}
