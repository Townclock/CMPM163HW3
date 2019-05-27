using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitByMagnitude : MonoBehaviour
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
		float magnitude = 0;
		for (int i = 0; i < 1024; i++)
			magnitude += data[i];
		
		if (magnitude > 0.8)
			particleSystem.Emit(1);
    }
}
