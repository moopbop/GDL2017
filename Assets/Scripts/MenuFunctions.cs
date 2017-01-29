using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

    private void Start()
    {
        if (this.gameObject != GameObject.Find("MainMenu"))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ClickedStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void changeMenu(GameObject menu)
    {
        menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
