using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemieAi : MonoBehaviour {
    private UpdatedPlayerController player;
    public GameObject effectToSpawn;
    public GameObject firePoint;
    public GameObject turret;
    public float shootCD;
    public float cdTimer = 0f;
    public AudioSource ads;
    public AudioClip ac;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<UpdatedPlayerController>();
        ads.clip = ac;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance < 200)
        {
            RaycastHit rayCastHit;
            Physics.Raycast(turret.transform.position, player.transform.position - turret.transform.position, out rayCastHit, 10);
            if (rayCastHit.collider == null)
            {
                return;
            }
            else if (rayCastHit.collider.gameObject.tag == "Player")
            {
                Vector3 displacement = player.transform.position - turret.transform.position;
                displacement.y = 0;
                turret.transform.rotation = Quaternion.LookRotation(displacement);
                if((Time.time *1000) - cdTimer > shootCD)
                {
                    cdTimer = Time.time * 1000f;
                    shootPlayer();
                }
               

            }
        }
    }

    private void shootPlayer()
    {
        Debug.Log("you have been shot");
        GameObject arrow = Instantiate(effectToSpawn, firePoint.transform.position, turret.transform.rotation);
        ads.Play();
    }
}
