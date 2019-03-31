using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject canvas;
    public Image BG;
    public Image textBox;
    public Text one;
    public Text two;
    public UpdatedPlayerController pc;
    public bool passed;
    public bool triggered;
    public int sceneNumber;
    public AudioSource ads;
    public AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        passed = false;
        ads.clip = ac;
    }

    // Update is called once per frame
    void Update()
    {
        if (passed && !triggered)
        {
            triggered = true;
            float time = Time.time - pc.startTime;
            one.text= "Time Taken :" + time + " sec";
            two.text = "Secrects found " + pc.secrectItem;
            canvas.gameObject.SetActive(true);
            ads.Play();
        }
        if (passed)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(sceneNumber);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            passed = true;
        }
    }


}
