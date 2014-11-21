using UnityEngine;
using System.Collections;

public class DisableTarget : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		target.SetActive(false);
	}
}
