using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    public void Click()
    {
        SoundManager.instance.PlaySound(clickSound);
    }
}
