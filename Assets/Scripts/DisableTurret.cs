﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTurret : MonoBehaviour {

    public GameObject turret;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnergyArrow")
        {
            turret.gameObject.SetActive(false);
        }
    }
}
