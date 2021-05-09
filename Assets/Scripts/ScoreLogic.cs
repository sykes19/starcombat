using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ScoreLogic : MonoBehaviour
{
    private Label P1;
    private Label P2;
    public UIDocument UIRef;
    public int P1CurrentScore = 0;
    public int P2CurrentScore = 0;
    public GameLogic gLogic; // This is given to me on instantiation at the moment

    private void Awake()
    {
   
    }


    void Start()
    {
        // Bind references from UI labels
        var rootVE = UIRef.rootVisualElement;
        P1 = rootVE.Q<Label>("TextP1");
        P2 = rootVE.Q<Label>("TextP2");

        // Initialize labels
        P1.text = ("P1 - " + P1CurrentScore);
        P2.text = ("P2 - " + P2CurrentScore);
    }

    void UpdateScore()
    {
        // Receive new score values from ships
        P1CurrentScore = gLogic.AllShips[0].myScore;
        P2CurrentScore = gLogic.AllShips[1].myScore;

        // Push values to the UI labels
        P1.text = ("P1 - " + P1CurrentScore);
        P2.text = ("P2 - " + P2CurrentScore);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }


}
