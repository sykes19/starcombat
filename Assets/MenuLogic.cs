using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{

    void PartyTime()
    {

    }

    // Start is called before the first frame update
    void OnEnable()
    {
        SceneManager.LoadScene("Game1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
