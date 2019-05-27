using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorByFrequency : MonoBehaviour
{
		public AudioPeer source;
	private ParticleSystem particleSystem;
	
    // Start is called before the first frame update
    void Start()
    {
        
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		float[] data = source.GetData();
		float max = 0; 
		
		for (int i = 0; i < 1024; i++)
		{
			if (data[i] > 0.02) max = i;
	
		}
		max /= 512;
		Color col = Color.HSVToRGB(max, 1, 1);
		Debug.Log(max);
		ParticleSystem.MainModule main = particleSystem.main;
		main.startColor = col;
	}
}
