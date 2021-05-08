using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLogic : MonoBehaviour
{

    public TextMeshProUGUI text_P1score;
    public TextMeshProUGUI text_P2score;
    public int P1CurrentScore = 0;
    public int P2CurrentScore = 0;
    public GameObject gameController;
    GameLogic gLogic;

    // Start is called before the first frame update
    void Start()
    {
        gLogic = gameController.GetComponent<GameLogic>();
        text_P1score.text = ("P1 - " + P1CurrentScore);
        text_P2score.text = ("P2 - " + P2CurrentScore);
    }

    void UpdateScore()
    {
        P1CurrentScore = gLogic.AllShips[0].myScore;
        P2CurrentScore = gLogic.AllShips[1].myScore;
        //string debug = gLogic.AllShips.ToString();
        //print(debug);
        text_P1score.text = ("P1 - " + P1CurrentScore);
        text_P2score.text = ("P2 - " + P2CurrentScore);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }


}
