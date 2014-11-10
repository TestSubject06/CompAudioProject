using UnityEngine;
using System.Collections;

public class OffsetChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * 0.8f;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
