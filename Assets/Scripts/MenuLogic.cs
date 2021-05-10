using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuLogic : MonoBehaviour
{
    private VisualElement playButton;
    public GameObject StarSpawnerObject;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game1");
    }

    private void Start()
    {
        Instantiate(StarSpawnerObject);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        var rootVE = GetComponent<UIDocument>().rootVisualElement;

        playButton = rootVE.Q<Button>("PlayButton");

        playButton.RegisterCallback<ClickEvent>(ev => PlayGame());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
