using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    public GameObject hostShip;
    public float Lifetime = 2;
    public ShipLogic hostLogic;

    // Start is called before the first frame update
    void Start()
    {
        hostLogic = hostShip.GetComponent<ShipLogic>();
    }

    public void HitBadguy()
    {
        hostLogic.myScore++;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime < 0) { Destroy(gameObject);}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != hostShip.GetComponent<Collider>())
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<ShipLogic>().DeathCode();
                HitBadguy();
            }
        }

    }

    private void OnDestroy()
    {
        // DEBUG LINE TO ADD SCORE FOR NOW
        //HitBadguy();
    }
}
