using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linus : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float velocity;
    void Start()
    {
        
    }

    
    void Update()
    {
        move();
    }
    void move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        this.rigidbody.velocity = new Vector3(horizontal,0, vertical) * velocity;

    }
}
