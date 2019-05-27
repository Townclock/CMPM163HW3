using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchArt : MonoBehaviour
{
	
	public Material material;
    // Start is called before the first frame update
    void Start()
    {
		 material = GetComponent<Renderer>().material;
		 material = Instantiate(material);
		 GetComponent<Renderer>().material = material;
		 
    }

    // Update is called once per frame
    void Update()
    {
	if (Time.time % 0.5f <= 1f)
		{	
			if (Random.value > 0.9)
			{
				if (Random.value > 0.5)
				{
					material.SetFloat("_RandomX", Random.Range(-1f, 1f));
					material.SetFloat("_RandomY", Random.Range(-1f, 1f));
				}
				else{
					material.SetFloat("_RandomX", 0);
					material.SetFloat("_RandomY", 0);
				}	
			}

		}
    }
}
