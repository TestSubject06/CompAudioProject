using UnityEngine;
using System.Collections;

public class SetNumber : MonoBehaviour {


	// Use this for initialization
	public AudioClip[] clips = new AudioClip[4];
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("h")){ 
			audio.clip = clips[0];
			audio.Play (); 
		}
		if (Input.GetKey("j")){ 
			audio.clip = clips[1];
			audio.Play (); 
		}
		if (Input.GetKey("k")){ 
			audio.clip = clips[2];
			audio.Play (); 
		}
		if (Input.GetKey("l")){ 
			audio.clip = clips[3];
			audio.Play (); 
		}
	
	}
}
