using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasText : Parent {

	public Text label;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void enterAction(Collider c) {
		updateLabel (c.name);
	}
	private void updateLabel(string message) {
		label.text = message;
	}

	public override void leaveAction(Collider c) {
		resetLabel ();
	}

	private void resetLabel() {
		label.text = "";
	}
}
