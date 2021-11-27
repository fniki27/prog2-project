using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private Animator anim; 
    private BoxCollider2D boxCollider;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        anim.SetBool("grounded", isGrounded());
        if (PlayerWin.hasWon == true)
        {
            anim.SetTrigger("win");
        }
        
    }

    private void WinJump()
    {
        if (isGrounded())
        {
            anim.SetTrigger("winjump");
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
