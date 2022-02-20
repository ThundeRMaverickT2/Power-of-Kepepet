using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource _AudioClip;
    [SerializeField] AudioClip playAudio;
    [SerializeField] AudioClip hovered;
    [SerializeField] AudioClip hoveredout;

    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void HoverSound()
    {
        _AudioClip.PlayOneShot(hovered);
    }

    public void ClickedAudio()
    {
        _AudioClip.PlayOneShot(playAudio);
    }

    public void HoverOutSound()
    {
        _AudioClip.PlayOneShot(hoveredout);
    }
}
