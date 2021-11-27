using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingTile : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Invoke("Drop", speed);
            Destroy(gameObject, 2f);
        } 
    }

    void Drop()
    {
        rb.isKinematic = false;
    }
}
