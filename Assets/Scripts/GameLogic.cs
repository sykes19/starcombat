using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject ShipObject;
    public GameObject BulletObject;
    public GameObject ScoreObject;
    public GameObject UIObject;
    public List<ShipLogic> AllShips = new List<ShipLogic>();
    public int scoreToWin;
    public int MaxPlayers;

    //int Players;
    //GameObject[] PlayerShips;

    // Start is called before the first frame update
    void Awake()
    {
        //Players = 2;
        AllShips.Clear();
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllShips[0].myScore == 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (AllShips[1].myScore == 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void FixedUpdate()
    {
 
    }

    // Populate scene with game-specific objects
    void Begin()
    {
        //Create UI controller object
        GameObject objUI = Instantiate(UIObject);
        UIDocument UIDoc = objUI.GetComponent<UIDocument>();

        //Create ScoreController, and bind to logic script
        GameObject scoreController = Instantiate(ScoreObject);
        ScoreLogic sLogic = scoreController.GetComponent<ScoreLogic>();
        //Give ScoreLogic a reference to my own logic script
        sLogic.gLogic = GetComponent<GameLogic>();
        sLogic.UIRef = UIDoc;

        //Ship creation
        GameObject PlayerShip = Instantiate(ShipObject, new Vector3(7, 3, 1), Quaternion.Euler(0, -90, -90));
        ShipLogic Logic = PlayerShip.GetComponent<ShipLogic>();
        Logic.Player = (1);
        AllShips.Insert(0, Logic);

        PlayerShip = Instantiate(ShipObject, new Vector3(-7, -3, 1), Quaternion.Euler(0, 90, 90));
        Logic = PlayerShip.GetComponent<ShipLogic>();
        Logic.Player = (2);
        AllShips.Insert(1, Logic);
    }

    // Destory all existing objects
    void End()
    {

    }
}
