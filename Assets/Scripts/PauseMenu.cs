using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool ispaused = false;
    public GameObject escapeMenu;
    public GameObject controllsMenu;
    

	// Use this for initialization
	void Start () {
        ispaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeMenu.gameObject.activeInHierarchy == false)
            {
                escapeMenu.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                Camera.main.GetComponent<CameraController>().enabled = false;
                ispaused = true;
            } else
            {
                escapeMenu.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                Camera.main.GetComponent<CameraController>().enabled = true;
                controllsMenu.SetActive(false);
                ispaused = false;
            }
        }
	}

    public void ContinueGame()
    {
        escapeMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Camera.main.GetComponent<CameraController>().enabled = true;
        controllsMenu.SetActive(false);
        ispaused = false;
    }

    public void restartGame()
    {
        // Application.LoadLevel(Application.loadedLevel);
        escapeMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Camera.main.GetComponent<CameraController>().enabled = true;
        controllsMenu.SetActive(false);
        ispaused = false;
        SceneManager.LoadScene(0);
    }

    public void controllesGame()
    {
        controllsMenu.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void closeControllGame() {
        ispaused = false;
        controllsMenu.SetActive(false);
    }
}
