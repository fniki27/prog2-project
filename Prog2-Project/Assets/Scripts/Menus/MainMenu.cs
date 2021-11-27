using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    public void Play()
    {
        SoundManager.instance.PlaySound(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Options()
    {
        SoundManager.instance.PlaySound(clickSound);
    }

    public void Quit()
    {
        SoundManager.instance.PlaySound(clickSound);
        Application.Quit();
    }

}
