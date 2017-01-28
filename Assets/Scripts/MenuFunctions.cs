using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

    private void Start()
    {

    }

    public void ClickedStart()
    {
        SceneManager.LoadScene("Main");
    }
}
