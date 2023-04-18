using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeController : MonoBehaviour
{
    public Rigidbody2D firstHook;

    public Ball _Ball;
    public int connectionCount = 5;
    public GameObject connectionPrefab;
    void Start()
    {
        createRope();
    }

    void createRope()
    {
        Rigidbody2D previousConnection = firstHook;

        for(int i = 0; i < connectionCount; i++)
        {
            GameObject connection = Instantiate(connectionPrefab,transform);
            HingeJoint2D joint = connection.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousConnection;

            if(i < connectionCount - 1)
            {
                previousConnection = connection.GetComponent<Rigidbody2D>();
            }
            else
            {
                _Ball.Connection(connection.GetComponent<Rigidbody2D>());
            }
        }
    }

    void Update()
    {
        
    }
}
