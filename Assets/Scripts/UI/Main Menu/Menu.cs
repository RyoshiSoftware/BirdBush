using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    Button startButton;


    private void Awake()
    {
        startButton = GetComponentInParent<Button>();
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
