using UnityEngine;
using System.Collections;


public class DoorTrigger : MonoBehaviour {

	//Class held by all door trigger zones in scene. Handles animator state that's assigned manually in the inspector.
	//Modify coroutine float to change door close delay time!

	const string ANIM_BOOL = "openDoor";
	public Animator animator;

	

	void Start() {
	
	}

	void OnTriggerEnter(Collider other) {
        print("door");
		StopAllCoroutines();
		ToggleAnimatorState(other, true);
	}

	void OnTriggerExit(Collider other) {
		ToggleAnimatorState(other, false);
	}

	void ToggleAnimatorState(Collider c, bool boolean) {
		
	}

	void PlayAudio(Collider c, AudioClip[] ac) {
		
	}

	IEnumerator DelayedDoorClose(float secs) {
		yield return new WaitForSeconds(secs);
		animator.SetBool(ANIM_BOOL, false);
		if (animator.name.Contains("Garage")) {
			
		}
	}
}
