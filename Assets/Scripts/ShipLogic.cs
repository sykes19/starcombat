using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    public GameObject BulletObject;
    new Rigidbody rigidbody;
    
    // Define what paint can be used, and what parts get painted
    public Material bluePaint;
    public Material yellowPaint;
    public GameObject paintedParts;

    public int Player = 0;
    public float Acceleration = 3.0f;
    public float TurnRate = 3.0f;
    public float MaxSpeed = 10.0f;
    public float BulletSpeed = 12.0f;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.detectCollisions = false;

        // Detect paintable parts of the ship.
        Renderer[] wingColor = paintedParts.GetComponentsInChildren<Renderer>();
        if (Player == 1)
        {   // Paint each paintable piece, one by one.
            foreach (Renderer rend in wingColor) { rend.material = bluePaint; }
        }
        else if (Player == 2)
        {
            foreach (Renderer rend in wingColor) { rend.material = yellowPaint; }
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player == 1)
        {
            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(transform.forward * Acceleration); }
            if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(transform.forward * -Acceleration); }
            if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -TurnRate, 0)); }
            if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, TurnRate, 0)); }
            if (Input.GetKeyDown(KeyCode.Space)) { Shoot(); }
        }

        // Clamp max speed
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, MaxSpeed);
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletObject, transform.position, transform.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * BulletSpeed;
        Bullet.GetComponent<BulletLogic>().Player = Player; // Set bullet ownership
    }

}
