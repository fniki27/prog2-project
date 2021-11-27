using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public Transform point1, point2;
    public float speed;
    public Transform startPosition;
    Vector3 nextPosition;

    private void Start()
    {
        nextPosition = startPosition.position;
    }

    private void Update()
    {
        if (transform.position == point1.position)
            nextPosition = point2.position;
        
        if (transform.position == point2.position)
            nextPosition = point1.position;

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(point1.position, point2.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);

        }
    }
}
