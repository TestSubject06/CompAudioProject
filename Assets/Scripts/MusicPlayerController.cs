using UnityEngine;
using System.Collections;

public class MusicPlayerController : MonoBehaviour {


	public float quietTime;
	public bool hasStarted = false;
	
	// Update is called once per frame
	void Update () {
		if(hasStarted){
			if(quietTime > 0){
				quietTime -= Time.deltaTime;
				audio.volume = Mathf.Max(0.10f, audio.volume-0.05f);
			}else{
				audio.volume = Mathf.Min(0.60f, audio.volume+0.05f);
			}
		}else{
			quietTime += Time.deltaTime;
			audio.volume += 0.001f;
			if(quietTime > 6.0f){
				hasStarted = true;
				quietTime = 0.0f;
			}
		}
	}

	//Lowers the volume for seconds seconds.
	public void LowerVolume(float seconds){
		quietTime = seconds;
		hasStarted = true;
	}

}