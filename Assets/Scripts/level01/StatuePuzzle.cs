using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{
    public bool activated;
    private Quaternion enabled;
    private Quaternion disabled;
    public Collider trigArea;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        enabled = Quaternion.Euler(-90, 90, 0);
        disabled = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            this.transform.rotation = Quaternion.Lerp(enabled, disabled, Time.deltaTime * 1f);
            trigArea.enabled = false;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activated = true;
            }
        }
    }

    public bool getisActivated() {
        return activated;
    }
}

