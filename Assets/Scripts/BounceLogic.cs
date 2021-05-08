using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLogic : MonoBehaviour
{
    public Vector2 Boundary;
    new Rigidbody rigidbody;

    static Vector3 MirrorX = new Vector3(-1f, 1f, 1f);
    static Vector3 MirrorY = new Vector3(1f, -1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // If at or beyond bounds, multiply X or Y component of velocity by -1
        if (transform.position.x >= Boundary.x) { rigidbody.velocity = Vector3.Scale(rigidbody.velocity, MirrorX); }
        if (transform.position.x <= -Boundary.x) { rigidbody.velocity = Vector3.Scale(rigidbody.velocity, MirrorX); }
        if (transform.position.y >= Boundary.y) { rigidbody.velocity = Vector3.Scale(rigidbody.velocity, MirrorY); }
        if (transform.position.y <= -Boundary.y) { rigidbody.velocity = Vector3.Scale(rigidbody.velocity, MirrorY); }
    }
}
