using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrowMomentScript : MonoBehaviour {

    public Vector3 Position;
    public Vector3 Position2;
    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {
       
        min = this.transform.position.y;
        max = this.transform.position.y + 3;
        
        

    }
    void Update()
    {


        transform.position = new Vector3( transform.position.x, Mathf.PingPong(Time.time * 5, max - min) + min, transform.position.z);

    }
}
