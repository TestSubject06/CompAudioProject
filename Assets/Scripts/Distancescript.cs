using UnityEngine;
using System.Collections;

public class Distancescript : Parent {
	public AudioClip clip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void enterAction (Collider c)
	{
		audio.clip = clip;
		audio.Play ();
	}

	public override void leaveAction (Collider c)
	{
		audio.Stop ();
	}
}
