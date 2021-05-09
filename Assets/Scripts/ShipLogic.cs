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
    public AudioSource beep;
    
    public int myScore;
    public int Player;
    public float Acceleration;
    public float TurnRate;
    public float MaxSpeed;
    public float BulletSpeed;
    public float RespawnTime;
    public int WeaponCooldown;
    int CurrentWeaponCooldown;

    string state = "alive";
    float timer;

    private void Respawn()
    {
        state = "alive";
        // Reset all relevant values to default when respawning
        if (Player == 1)
        {   // Determine spawn position based on player
            this.transform.position = (new Vector3(7, 3, 1));
        }
        else
        {
            this.transform.position = (new Vector3(-7, -3, 1));
        }
        gameObject.GetComponent<Collider>().enabled = true;
        rigidbody.velocity -= rigidbody.velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = "alive";
        rigidbody = GetComponent<Rigidbody>();

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
        if (state == "dead")
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Respawn();
            }
        }
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
            if (Player == 2)
            {
                if (Input.GetKey(KeyCode.Home)) { rigidbody.AddForce(transform.forward * Acceleration); }
                // The original game didn't let you go backwards, and I don't like how it feels. Trying it out.
                //if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(transform.forward * -Acceleration); }
                if (Input.GetKey(KeyCode.Delete)) { transform.Rotate(new Vector3(0, -TurnRate, 0)); }
                if (Input.GetKey(KeyCode.PageDown)) { transform.Rotate(new Vector3(0, TurnRate, 0)); }
                if (Input.GetKey(KeyCode.End) && (CurrentWeaponCooldown == 0)) { Shoot(); }
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

    public void DeathCode()
    {
        // Disable this ship while respawning
        state = "dead";
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, 100);
        timer = RespawnTime;
    }
}
