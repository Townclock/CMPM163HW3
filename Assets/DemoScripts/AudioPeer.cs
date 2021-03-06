﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create this required component....
[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour {

	// need to instantiate an audio source and array of samples to store the fft data.

	AudioSource _audioSource;

	// NOTE: make this a 'static' float so we can access it from any other script.
	public static float[] spectrumData = new float[2048]; // 10.8 hz fidelity



	// Use this for initialization
	void Start () {
		
		_audioSource = GetComponent<AudioSource> ();	

	}


	// Update is called once per frame
	void Update () {

		GetSpectrumAudioSource ();

	}


	void GetSpectrumAudioSource()
	{
		// this method computes the fft of the audio data, and then populates spectrumData with the spectrum data.
		_audioSource.GetSpectrumData (spectrumData, 0, FFTWindow.Hanning);
	}
	
	public float[] GetData(){return spectrumData;}
}


