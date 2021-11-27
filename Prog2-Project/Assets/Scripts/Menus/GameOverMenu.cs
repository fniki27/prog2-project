using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] public AudioClip clickSound;

    public void Menu(int sceneID)
    {
        SoundManager.instance.PlaySound(clickSound);
        SceneManager.LoadScene(sceneID);
    }

    public void TryAgain(int sceneID)
    {
        SoundManager.instance.PlaySound(clickSound);
        SceneManager.LoadScene(sceneID);
    }


}
