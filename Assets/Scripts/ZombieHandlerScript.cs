using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHandlerScript : MonoBehaviour
{

    public Transform target;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent agent;
    public bool check = false;
    public static ZombieHandlerScript instance;
    public GameObject UI,Pausebutton;
    public Image BloodSplashes;
    public Transform TargetForLookAt, LookAtPointForGameOver;
    public SmoothMouseLook sml;
    public bool over;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.SelectedLevel != 1)
        { 
            if (other.gameObject.tag == "Player" && !check)
            {
                check = true;
                this.gameObject.GetComponent<Animator>().SetTrigger("run");
                this.gameObject.GetComponent<AudioSource>().enabled = false;
                agent.speed = 3.5f;

                if (!SoundManager.Instance.IsEffectsPlaying())
                    SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.Sunspense);
                SoundManager.Instance.EffectsVolume = 0.5f;

            }
        }
        if (other.gameObject.tag == "secondlevel"){
            
             Invoke("LevelComleted", 1f);
        }

    }
  public void GameOver()
    {
        
        UiManager.Instance.OnLevelFailed.Invoke();
        
    }

    public void LevelComleted(){
        UiManager.Instance.OnLevelCompleted.Invoke();
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player" && check)
        {
            check = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("walk");
            this.gameObject.GetComponent<AudioSource>().enabled = false;
            print("sdfdsdfd");
            //agent.enabled = false;
            agent.speed = 2f;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            Debug.Log(collision.gameObject.tag);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.levelCompleteCheck)
            agent.enabled = false;


        if (check )
        {
            //Debug.Log("zombie is start......");
            this.GetComponent<Animator>().enabled = true;
            agent.enabled = true;
            agent.SetDestination(target.position);
            this.transform.LookAt(Camera.main.transform);
            //this.gameObject.GetComponent<Animator>().SetTrigger("walk");
            //if(!SoundManager.Instance.IsEffectsPlaying())
            //    SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.ManScream);

        }
     
        

      
        if(agent.isActiveAndEnabled)
        if (check && agent.remainingDistance != 0 && agent.remainingDistance <= agent.stoppingDistance )
        {
            Debug.Log("zombie is sttoped......");
                this.gameObject.GetComponent<Animator>().SetTrigger("attack");
                UI.SetActive(false);
                over = true;
                target.gameObject.SetActive(false);
                
                Pausebutton.SetActive(false);
               
                //OverSceneClown.transform.position = this.gameObject.transform.position;
                //OverSceneClown.transform.rotation = this.gameObject.transform.rotation;
                //OverSceneClown.SetActive(true);
                //OverSceneCamera.SetActive(true);

                Invoke("EnableFrost", 1);
                Invoke("GameOver", 3);
                if (check && !agent.isStopped)
            {
                    
                
                agent.isStopped = true;

                
            }
          
                check = false;
                //this.gameObject.SetActive(false);
            }
        //else
        //{
        //    //Debug.Log("Agent is not stopped");
        //    agent.Resume();
        //    this.gameObject.GetComponent<Animator>().SetTrigger("walk");

        //}

        if (over)
        {
            Camera.main.transform.LookAt(LookAtPointForGameOver);
            CameraControl.instance.gameOver = true;
            sml.enabled = false;
        }

        
    }

    bool playsoundCheck = false;
    
    public void EnableFrost()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.gameOver);
        Camera.main.GetComponent<FrostEffect>().enabled = true;
    }

}