using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Companion : MonoBehaviour
{

    public Transform target;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent agent;
    public bool check = false;
    public static Companion instance;
    public Animator KidAnimation;
    public bool walking;
    public GameObject RunButton;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        RunButton.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.SelectedLevel != 1)
        { 
            if (other.gameObject.tag == "Player" && !check)
            {
                check = true;
              
                agent.speed = 1f;

            

            }
        }
      

    }
  

  

    private void OnCollisionEnter(Collision collision)
    {
        
            Debug.Log(collision.gameObject.tag);
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (check )
        {
            //Debug.Log("zombie is start......");
            if (FPSRigidBodyWalker.instance.moving)
            {
                if (!walking)
                {
                    walking = true;
                    KidAnimation.SetTrigger("walk");
                }
            }

            else
            {
                if (walking)
                {
                    walking = false;
                    KidAnimation.SetTrigger("idle");
                }
               

            }
            agent.SetDestination(target.position);
            transform.rotation = target.rotation;
            //this.transform.LookAt(Camera.main.transform);
            //this.gameObject.GetComponent<Animator>().SetTrigger("walk");
            //if(!SoundManager.Instance.IsEffectsPlaying())
            //    SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.ManScream);

        }
     
        

      
      
        //else
        //{
        //    //Debug.Log("Agent is not stopped");
        //    agent.Resume();
        //    this.gameObject.GetComponent<Animator>().SetTrigger("walk");

        //}

      

        
    }
 

}