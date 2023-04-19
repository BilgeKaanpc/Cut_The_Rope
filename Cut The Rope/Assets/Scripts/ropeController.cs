using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeController : MonoBehaviour
{
    public Rigidbody2D firstHook;

    public Ball _Ball;
    public int connectionCount = 5;

    public GameObject[] ropePool;
    public string hingeName;
    void Start()
    {
        createRope();
    }

    void createRope()
    {
        Rigidbody2D previousConnection = firstHook;

        for(int i = 0; i < connectionCount; i++)
        {
            ropePool[i].SetActive(true);
            HingeJoint2D joint = ropePool[i].GetComponent<HingeJoint2D>();
            joint.connectedBody = previousConnection;

            if(i < connectionCount - 1)
            {
                previousConnection = ropePool[i].GetComponent<Rigidbody2D>();
            }
            else
            {
                _Ball.Connection(ropePool[i].GetComponent<Rigidbody2D>(), hingeName);
            }
        }
    }

    void Update()
    {
        
    }
}
