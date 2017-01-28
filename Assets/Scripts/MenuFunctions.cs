using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

	void ClickedStart()
    {
        SceneManager.LoadScene("Main");
    }
}
