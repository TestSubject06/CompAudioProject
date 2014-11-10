using UnityEngine;
using System.Collections;

public class CharacterPush : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody body = hit.collider.attachedRigidbody;
		if(body == null || body.isKinematic) return;

		if(hit.moveDirection.y < -0.3) return;

		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);

		float pushPower = 2.0f;
		if(Input.GetKey(KeyCode.E))
			pushPower *= 5;
		body.velocity = pushDir * pushPower;
	}
}
