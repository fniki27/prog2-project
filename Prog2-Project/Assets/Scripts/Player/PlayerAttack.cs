using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

[SerializeField] private float attackCooldown;
[SerializeField] private Transform projectilePoint;
[SerializeField] private GameObject[] projectiles;
[SerializeField]private AudioClip projectileSound;

private Animator anim;
private PlayerMovement playerMovement;
private float cooldownTimer = Mathf.Infinity;
private float horizontalInput;

private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > attackCooldown && !PauseMenu.gameIsPaused)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

private void Attack()
    {
        SoundManager.instance.PlaySound(projectileSound);
        if(horizontalInput == 0)
           anim.SetBool("attack", PlayerMovement.isJumping == false);
        cooldownTimer = 0;

        projectiles[FindProjectile()].transform.position = projectilePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}
