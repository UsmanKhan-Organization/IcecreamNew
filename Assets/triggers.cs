using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggers : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Metal")
        {
            Debug.Log("other gameobject name "+other.gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Metal")
        {
            Debug.Log("AnimationTrigger");
            this.gameObject.GetComponent<Animator>().SetTrigger("throw");
        }
    }
    public void KidForward()
    {
        transform.position = pos;
        pos = new Vector3(pos.x, pos.y, pos.z + 2f);
    }
        
    
}
