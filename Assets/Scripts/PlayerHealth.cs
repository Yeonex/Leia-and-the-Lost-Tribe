using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;
    public bool isDead;
    public bool Damaged;
    public GameObject player;
    public int numberOfSmallHealthKits;
    public int numberOfLargeHealthKits;
    public Text HP;
    public Color flashColour = new Color(255f, 255f, 255f, 1f);
    public float flashSpeed = 5f;
    [Header("SoundClips")]
    public AudioSource ads;
    public AudioClip healed;
    public AudioClip no;
    public AudioClip dmgSound;
    public AudioClip death;
    [Header("Potion stuff")]
    public Text numberofHPPots;
    public Text deadText;




    private void Awake()
    {
        isDead = false;
        Damaged = false;
        PlayerMaxHealth = 100;
        PlayerCurrentHealth = PlayerMaxHealth;
        ads.clip = healed;
        deadText.gameObject.SetActive(false);

    }

    // Use this for initialization
    void Start () {
        HP.text = "♥" + PlayerCurrentHealth + " /" + PlayerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Damaged)
        {
            //change UI later;
            HP.text = "♥" + PlayerCurrentHealth + " /" + PlayerMaxHealth;
         //   HP.color = flashColour;
        }
        else
        {
            //reset UI flash
            //  HP.color = Color.Lerp(HP.color, Color.clear, flashSpeed * Time.deltaTime);
            HP.text = "♥" + PlayerCurrentHealth + " /" + PlayerMaxHealth;
        }
        numberofHPPots.text = "" + numberOfSmallHealthKits;
        Damaged = false;

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (PlayerCurrentHealth == 100)
            {
                ads.clip = no;
                ads.Play();
            }
            else
            {
                if (numberOfSmallHealthKits > 0)
                {
                    numberOfSmallHealthKits -= 1;
                    PlayerCurrentHealth += 50;
                    ads.clip = healed;
                    ads.Play();
                    if (PlayerCurrentHealth >= PlayerMaxHealth)
                    {
                        PlayerCurrentHealth = PlayerMaxHealth;
                        ads.clip = healed;
                        ads.Play();
                    }
                }
                else if (numberOfLargeHealthKits > 0)
                {
                    numberOfLargeHealthKits -= 1;
                    PlayerCurrentHealth = PlayerMaxHealth;
                    ads.clip = healed;
                    ads.Play();
                }
            }
        }
	}

    public void TakeDamage(int ammount) {
        Damaged = true;
        PlayerCurrentHealth -= ammount;
        ads.clip = dmgSound;
        ads.Play();

        if(PlayerCurrentHealth <= 0)
        {
            deadText.gameObject.SetActive(true);
            player.GetComponentInChildren<Animator>().Play("Death");
            ads.clip = death;
            ads.Play();
            Invoke("resetOnDeath", 3);

        }
    }

    public void addHelthPack(int type)
    {
        //0 for small || 1 for large

        if(type == 0)
        {
            numberOfSmallHealthKits += 1;
        } else
        {
            numberOfLargeHealthKits += 1;
        }
    }

    public void resetOnDeath()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
