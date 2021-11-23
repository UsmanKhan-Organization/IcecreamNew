using UnityEngine;


public class AudioClipsSource : MonoBehaviour
{

    [Header("Music Clips")]
    public AudioClip MainMenuClip;
    public AudioClip LevelSelectionClip;
    public AudioClip GamePlayClip;

    public AudioClip PlayButtonClick;
    public AudioClip CloseButtonClip;
    public AudioClip GenericButtonClip;

    public AudioClip LevelFailedClip;
    public AudioClip LevelSuccessClip;

    public AudioClip AchievementUnlockedClip;
    public AudioClip JumpScars;
    public AudioClip typewritterEfect;
    public AudioClip grab;
    public AudioClip finish;
    public AudioClip gameOver;
    public AudioClip openDoor;
    public AudioClip thanku;
    public AudioClip Thunder,Thunder2;
    public AudioClip Sunspense;


    public static AudioClipsSource Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
          //  DontDestroyOnLoad(this.gameObject);
        }
    }







}
