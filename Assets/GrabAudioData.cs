using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAudioData : MonoBehaviour
{
	public AudioPeer source;
	public Material material;
	public int id = 0;
	public Vector3 orientation;
	static int[] orientations = {-1, 1};
	static public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
		orientation = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
		counter++;
		counter %= 90;
		if (counter == 0)
		{
			orientation.x = orientations[Random.Range(0, 1)];
			
			orientation.y = orientations[Random.Range(0, 1)];
			
			orientation.z = orientations[Random.Range(0, 1)];
			
		}
		
		float[] data = source.GetData();
		if (data[id*50] > 0.001)
			material.SetFloat("_RandomX", data[id*50]*300 * orientation.x);
		else 
			material.SetFloat("_RandomX", 0);
		if (data[id*75] > 0.001)
			material.SetFloat("_RandomY", data[id*75]*300* orientation.y);
				else 
			material.SetFloat("_RandomY", 0);
		if (data[id*100] > 0.001)
			material.SetFloat("_RandomZ", data[id*100]*300* orientation.z);
		else 
			material.SetFloat("_RandomZ", 0);
    }
}
