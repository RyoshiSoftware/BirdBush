using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] GameObject closeGameUI;
    [SerializeField] InputManager inputManager;

    private GameObject quitCopy = null;
    private bool isMenuUp;


    private void Update() 
    {
        QuitChecker();
    }

    private void QuitChecker()
    {
        if (!inputManager.QuitPressedThisFrame()) { return; }

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenuScene")) { SceneManager.LoadScene("MainMenuScene"); }
        
        if (quitCopy != null) { Destroy(quitCopy); }
        else 
        { 
            quitCopy = Instantiate(closeGameUI); 
        }  
    }


}
