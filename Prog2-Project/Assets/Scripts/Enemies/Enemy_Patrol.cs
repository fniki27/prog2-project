using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enemy_Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    //The int value for next point index
    [SerializeField] private int nextID = 0;
    int idChangeValue = 1;
    [SerializeField] private float speed = 2;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private Behaviour[] components;

    private Animator anim; 
    private bool dead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "_Patrol");
    
        root.transform.position = transform.position;
      
        transform.SetParent(root.transform);
    
        GameObject waypoints = new GameObject("Waypoints");
      

        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform);p2.transform.position = root.transform.position;

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
     
        Transform goalPoint = points[nextID];
     
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(2, 2, 2);
        else
            transform.localScale = new Vector3(-2, 2, 2);
     
        if (!dead)
        {
            transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
            
            if(Vector2.Distance(transform.position, goalPoint.position)<0.2f)
            {
                if (nextID == points.Count - 1)
                    idChangeValue = -1;
        
                if (nextID == 0)
                    idChangeValue = 1;
                    nextID += idChangeValue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            dead = true;
            SoundManager.instance.PlaySound(dieSound);
            anim.SetTrigger("die");
            foreach (Behaviour component in components)
                    component.enabled = false;
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
