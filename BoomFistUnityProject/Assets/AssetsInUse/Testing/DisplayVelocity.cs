using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayVelocity : MonoBehaviour
{
    public Rigidbody Rigidbody;

    private float speed;
    
    void FixedUpdate()
    {
        speed = Rigidbody.velocity.y;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Measurements");

        GUI.Label(new Rect(20, 40, 80, 20), speed + "m/s");
    }
}
