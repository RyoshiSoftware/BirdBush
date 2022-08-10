using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
   [SerializeField] Button quitConfirm;

   private void Awake() 
   {
        quitConfirm.onClick.AddListener(EndGame); 
   }

    private void EndGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
