using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThreeDoor : MonoBehaviour
{

    public GameObject button;
    public Button btn;
    public float keepalive = 10f;
    public float speed = 2f;
    private bool door;
    // Start is called before the first frame update
    void Start()
    {
        btn = button.GetComponent<Button>();
        door = false;
    }

    private void FixedUpdate()
    {
        // transform.position += transform.forward * speed * Time.fixedDeltaTime;
        if (door)
        {
            this.transform.position -= transform.up * speed * Time.fixedDeltaTime;
            keepalive -= Time.fixedDeltaTime;
        }
        if (keepalive <= 0)
        {
             Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (btn.isPressed)
        {
            door = true;
        }
    }
}
