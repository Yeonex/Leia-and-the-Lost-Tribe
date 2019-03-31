using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class control : MonoBehaviour
{
    public float timer = 3f;
    public bool startNewGame;
    // Start is called before the first frame update
    void Start()
    {
        startNewGame = false;
    }
    private void FixedUpdate()
    {
        if (startNewGame)
        {
            timer -= Time.fixedDeltaTime;
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNewGame()
    {
        startNewGame = true;
    }

    public void onExit()
    {
        Application.Quit();
    }
}
