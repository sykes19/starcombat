using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject ShipObject;
    public GameObject BulletObject;

    //int Players;
    //GameObject[] PlayerShips;

    // Start is called before the first frame update
    void Start()
    {
        //Players = 2;
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create new ships
    void Begin()
    {
        GameObject PlayerShip = Instantiate(ShipObject, new Vector3(7, 3, 1), Quaternion.Euler(0, -90, -90));
        ShipLogic Logic = PlayerShip.GetComponent<ShipLogic>();
        Logic.Player = 1;

        PlayerShip = Instantiate(ShipObject, new Vector3(-7, -3, 1), Quaternion.Euler(0, 90, 90));
        Logic = PlayerShip.GetComponent<ShipLogic>();
        Logic.Player = 2;
    }

    // Destory all existing objects
    void End()
    {

    }
}
