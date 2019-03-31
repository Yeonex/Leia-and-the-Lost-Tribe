using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public PlayerHealth hp;
    public Animator anime;
    public bool attacking;
    public float health;
    private bool died;
    public float dispawnTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        hp = player.gameObject.GetComponent<PlayerHealth>();
        health = 100;
        died = false;
    }
    private void FixedUpdate()
    {
        if (died)
        {
            dispawnTimer -= Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 diff = this.transform.position - player.transform.position;
        float mag = Vector3.SqrMagnitude(diff);
        if (mag < 225)
        {
            Vector3 target = player.transform.position + diff.normalized * 2;
            navMeshAgent.SetDestination(target);
            anime.SetBool("moving", true);
        }
        else {
            anime.SetBool("moving", false);
        }
       if(Vector3.Distance(player.transform.position,this.transform.position) < 4 && !attacking)
        {
            anime.SetTrigger("attack");
            attacking = true;
        }
        if (health <= 0 && !died) {
            anime.SetTrigger("Died");
            anime.SetBool("hasDied", true);
            died = true;
        }
        if (died)
        {
            navMeshAgent.isStopped = true;
            if (dispawnTimer <= 0) {
                Destroy(this.gameObject);
                    }

        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireArrow" || other.gameObject.tag == "IceArrow" || other.gameObject.tag == "WindArrow" || other.gameObject.tag == "EnergyArrow")
        {
            health -= 35;
        }
    }
}
