using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWithLifeTimeWithNoise : MonoBehaviour {

	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		float newTime =  Mathf.PerlinNoise(1f,  Time.time / 10) *10;
		var newMain = ps.main;
		newMain.startLifetime = newTime;
		//ps.main = newMain;
	}
}
