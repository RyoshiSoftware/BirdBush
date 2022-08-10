using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{   
    private static InputManager _instance;

    public static InputManager Instance
    {
        get 
        {
            return _instance;
        }
    }
    private ControllerSampleActions controls;

    private void Awake() 
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        controls = new ControllerSampleActions();
    }

    private void OnEnable() 
    {
        controls.Enable();    
    }
    
    private void OnDisable() 
    {
        controls.Disable();
    }

    public bool QuitPressedThisFrame()
    {
        return controls.LeftHand.PrimaryButton.triggered;
    }
}
