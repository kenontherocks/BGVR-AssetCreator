using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFlareSizer : MonoBehaviour {

	public float ogSize1, ogSize2;
	public ParticleSystem flare, crown;
    public float multiplyer = 1f;

	// Use this for initialization
	void Start () {
		flare = GetComponent<ParticleSystem> ();
		crown = transform.Find("Crown").GetComponent<ParticleSystem> ();

		ogSize1 = flare.main.startSize.constant;
		ogSize2 = crown.main.startSize.constant;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetSize(float percentage){
        if (flare) {
            ParticleSystem.MainModule flaremain = flare.main;
            flaremain.startSize = ogSize1 * percentage * multiplyer;
        }

        if (crown) {
            ParticleSystem.MainModule crownmain = crown.main;
            crownmain.startSize = ogSize2 * percentage * multiplyer;
        }
	}


}
