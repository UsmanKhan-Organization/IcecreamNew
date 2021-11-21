using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour {

    public float rotationSpeed = -15.0f;
    private float y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        //y += Time.deltaTime * 10;
        //transform.rotation = Quaternion.Euler(0, y, transform.rotation.z);
    }


}
