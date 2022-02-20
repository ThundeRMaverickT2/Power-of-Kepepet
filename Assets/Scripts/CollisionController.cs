using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] AudioClip _sfxFinish;
    [SerializeField] AudioClip _sfxCrash;
    [SerializeField] const int _timeToWait = 1;
    bool methodOnProgress = false;
    
    AudioSource shipAudio;

    private void Start()
    {
        shipAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (methodOnProgress)
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
        this.gameObject.GetComponent<Control>().enabled = false;
        Invoke("ReloadLevel", _timeToWait);
    }

    void ShipLanded()
    {
        methodOnProgress = true;
        shipAudio.PlayOneShot(_sfxFinish);
        this.gameObject.GetComponent<Control>().enabled = false;
        Invoke("LoadNextLevel", _timeToWait);
    }
    void LoadNextLevel()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        int nextActiveScene = currentActiveScene + 1;
        if (nextActiveScene == SceneManager.sceneCountInBuildSettings)
        {
            nextActiveScene = 0;
        }
        SceneManager.LoadScene(nextActiveScene);
;
    }
    public void ReloadLevel()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentActiveScene);
    }
}
   

