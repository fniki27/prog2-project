using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratsMenu : MonoBehaviour
{
    [SerializeField] public AudioClip clickSound;

    public void Menu(int sceneID)
    {
        SoundManager.instance.PlaySound(clickSound);
        SceneManager.LoadScene(sceneID);
    }

    public void Quit()
    {
        SoundManager.instance.PlaySound(clickSound);
        Application.Quit();
    }
}
