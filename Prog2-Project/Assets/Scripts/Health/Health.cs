using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    public static bool dead = false;

    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private Behaviour[] components;

    private void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtSound);
            anim.SetTrigger("hurt");
        }
        
        else
        {
            if (!dead || currentHealth == 0)
            {
                SoundManager.instance.PlaySound(dieSound);
                anim.SetTrigger("die");
                foreach (Behaviour component in components)
                         component.enabled = false;
                dead = true;

            }
        }
    }

    public void LoadNewScene()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
        dead = false;
     }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}