using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ropeDistance = .2f;

    public Dictionary<string, HingeJoint2D> hingeControl = new Dictionary<string, HingeJoint2D>();
    public void Connection(Rigidbody2D body, string hingeName)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        hingeControl.Add(hingeName, joint);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = body;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0, ropeDistance);

    }
}
