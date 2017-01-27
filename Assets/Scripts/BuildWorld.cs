using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWorld : MonoBehaviour {

    public GameObject building, homeBase;
    public Vector2 homeBasePosition;
    public float worldX, worldY;
    public float streetSize;

    // Use this for initialization
    void Start()
    {
        streetSize += building.transform.localScale.x;

        worldX *= streetSize;
        worldY *= streetSize;
        homeBasePosition *= streetSize;

        for (float x = 0f; x < worldX; x += streetSize)
        {
            for (float y = 0f; y < worldY; y += streetSize)
            {
                if (x == homeBasePosition.x && y == homeBasePosition.y)
                {
                    Vector3 position = new Vector3(homeBasePosition.x, 10, homeBasePosition.y);
                    Instantiate(homeBase, position, new Quaternion());
                }
                else
                {
                    Vector3 position = new Vector3(x, 3.75f, y);
                    GameObject temp = Instantiate(building, position, new Quaternion());
                }
            }
        }

    }
}
