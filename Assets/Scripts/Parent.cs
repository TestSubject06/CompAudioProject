using UnityEngine;
using System.Collections;

public abstract class Parent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void enterAction (Collider c){}
	public virtual void stayAction(Collider c) {}
	public virtual void leaveAction(Collider c){}
}
