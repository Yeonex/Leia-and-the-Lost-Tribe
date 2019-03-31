using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth hp;
    // Start is called before the first frame update
    void Start()
    {
       hp = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        hp.TakeDamage(15);
        this.gameObject.SetActive(false);
    }
}
