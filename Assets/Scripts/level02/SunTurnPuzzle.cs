using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunTurnPuzzle : MonoBehaviour
{
    public GameObject button;
    private Button btn;
    public bool sunTurned;
    public Light point;
    private bool triggeronce;
    // Start is called before the first frame update
    void Start()
    {
        btn = button.GetComponent<Button>();
        sunTurned = false;
        point.gameObject.SetActive(false);
        triggeronce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (btn.isPressed && !triggeronce)
        {
            this.transform.rotation = Quaternion.Lerp((Quaternion.Euler(0, -90, 0)), this.transform.rotation, Time.deltaTime * 6f);
            sunTurned = true;
            point.gameObject.SetActive(true);
            triggeronce = true;
        }
        
    }
}
