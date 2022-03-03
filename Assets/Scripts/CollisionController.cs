using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] AudioClip _sfxFinish;
    [SerializeField] AudioClip _sfxCrash;
    [SerializeField] const int _timeToWait = 1;
    
   
    

    [SerializeField] ParticleSystem _winParticle;
    [SerializeField] ParticleSystem _loseParticle;
    
    AudioSource shipAudio;

    bool methodOnProgress = false;
    bool collisionDisabled = false;

    private void Start()
    {
        shipAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("LoadedNextLevel");
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("CollisionHasBeenDisabled");
            collisionDisabled = !collisionDisabled;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log("ReloadLevel!");
            ReloadLevel();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (methodOnProgress || collisionDisabled)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("ThisIsSpawn");
                break;
            case "Finish":
                ShipLanded();
                break;
            case "Hazard":
                Debug.Log("PlayerTakeHeavyDamage");
                break;
            default:
                ShipCrash();
                break;

        }
    }

    void ShipCrash()
    {
        methodOnProgress = true;
        shipAudio.PlayOneShot(_sfxCrash);
        _loseParticle.Play(_loseParticle);
        this.gameObject.GetComponent<Control>().enabled = false;
        Invoke("ReloadLevel", _timeToWait);
    }

    void ShipLanded()
    {
        methodOnProgress = true;
        shipAudio.PlayOneShot(_sfxFinish);
        _winParticle.Play(_winParticle);
        this.gameObject.GetComponent<Control>().enabled = false;
        Invoke("LoadNextLevel", _timeToWait);
    }
    void LoadNextLevel()
    {
        GetLoadScene();
    }

    private static void GetLoadScene()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        int nextActiveScene = currentActiveScene + 1;
        if (nextActiveScene == SceneManager.sceneCountInBuildSettings)
        {
            nextActiveScene = 0;
        }
        SceneManager.LoadScene(nextActiveScene);
    }

    public void ReloadLevel()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentActiveScene);
    }

    public void OutofLevel()
    {
        methodOnProgress = true;
        shipAudio.PlayOneShot(_sfxCrash);
        this.gameObject.GetComponent<Control>().enabled = false;
        Invoke("ReloadLevel", _timeToWait);
    }
}
   

