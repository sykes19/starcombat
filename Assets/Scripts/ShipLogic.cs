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

    public int myScore;
    public int Player;
    public float Acceleration;
    public float TurnRate;
    public float MaxSpeed;
    public float BulletSpeed;
    public int WeaponCooldown;
    int CurrentWeaponCooldown;

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
    void Update()
    {

    }

    // FixedUpdate is called regularly at a set interval
    void FixedUpdate()
    {
        // Subtract 1 from weapon cooldown counter, down to 0.
        CurrentWeaponCooldown = CurrentWeaponCooldown > 0 ? CurrentWeaponCooldown - 1 : 0;

        if (Player == 1)
        {
            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(transform.forward * Acceleration); }
            // The original game didn't let you go backwards, and I don't like how it feels. Trying it out.
            //if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(transform.forward * -Acceleration); }
            if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -TurnRate, 0)); }
            if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, TurnRate, 0)); }
            if (Input.GetKey(KeyCode.Space) && (CurrentWeaponCooldown == 0)) { Shoot(); }
        }

        // Clamp max speed
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, MaxSpeed);
    }

    void Shoot()
    {
        CurrentWeaponCooldown = WeaponCooldown;
        GameObject Bullet = Instantiate(BulletObject, transform.position, transform.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * BulletSpeed;
        Bullet.GetComponent<BulletLogic>().hostShip = gameObject;
    }

}
