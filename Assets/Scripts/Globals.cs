using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
