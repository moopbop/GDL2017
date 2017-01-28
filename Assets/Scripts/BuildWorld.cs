﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWorld : MonoBehaviour {

    public GameObject building, homeBase, street;
    public Vector2 homeBasePosition;
    public float worldX;
    float streetSize, gridSize;

    // Use this for initialization
    void Start()
    {
        Vector3 tempVec3 = street.transform.localScale;

        float streetX = (street.transform.localScale.x + street.transform.localScale.z) * worldX - street.transform.localScale.z;
        street.transform.localScale = new Vector3(streetX, street.transform.localScale.y, street.transform.localScale.z);
        //street.transform.localScale;
        gridSize = street.transform.localScale.z + building.transform.localScale.x;

        worldX *= gridSize;
        homeBasePosition *= gridSize;

        for (float x = 0f; x < worldX; x += gridSize)
        {
            for (float y = 0f; y < worldX; y += gridSize)
            {
                if (x == homeBasePosition.x && y == homeBasePosition.y)
                {
                    Vector3 position = new Vector3(homeBasePosition.x, 10, homeBasePosition.y);
                    Instantiate(homeBase, position, new Quaternion(), this.transform);
                }
                else
                {
                    Vector3 position = new Vector3(x, 3.75f, y);
                    GameObject temp = Instantiate(building, position, new Quaternion(), this.transform);
                }
            }
        }

        for (float x = (building.transform.localScale.x / 2 + street.transform.localScale.z / 2); x < worldX - gridSize; x += gridSize)
        {
            Instantiate(street, new Vector3(x, 0, streetX/2 - (building.transform.localScale.x)/2), Quaternion.Euler(0, 90, 0), this.transform);
            Instantiate(street, new Vector3(streetX/ 2 - (building.transform.localScale.x) / 2, 0, x), Quaternion.Euler(0, 0, 0), this.transform);
        }

        //for (float x = (building.transform.localScale.x/2 + streetSize/2); x < worldX; x += gridSize)
        //{
        //    for (float y = 0; y < worldY; y += gridSize)
        //    {
        //        Instantiate(street, new Vector3(x, 0, y), Quaternion.Euler(0,90,0), this.transform);
        //    }
        //}

        //for (float x = 0f; x < worldX; x += gridSize)
        //{
        //    for (float y = (building.transform.localScale.z / 2 + streetSize / 2); y < worldY; y += gridSize)
        //    {
        //        Instantiate(street, new Vector3(x, 0, y), new Quaternion(), this.transform);
        //    }
        //}

        street.transform.localScale = tempVec3;
    }
}