using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float loadTime;
    [SerializeField] private int sceneID;

    private Rigidbody2D body;
    private Animator anim; 
    private BoxCollider2D boxCollider;
    public static bool hasWon = false;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        anim.SetBool("grounded", isGrounded());

        if (hasWon == true)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(sceneID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        body.velocity = new Vector3(0, 0, 0);
        if (collision.tag == "Win")
        {
            anim.SetTrigger("win");
            SoundManager.instance.PlaySound(winSound);
            foreach (Behaviour component in components)
                     component.enabled = false;
            hasWon = true;
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
