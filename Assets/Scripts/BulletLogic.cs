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

    void HitBadguy()
    {
        hostLogic.myScore++;
        // Destroy badguy
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime < 0) { Destroy(gameObject);}
    }

    private void OnDestroy()
    {
        // DEBUG LINE TO ADD SCORE FOR NOW
        HitBadguy();
    }
}
