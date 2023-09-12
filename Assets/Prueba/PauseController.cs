using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioGlobalParameterTrigger volume;
    [SerializeField] bool isPressed;

    private void OnEnable()
    {
        InputManager.Onpause += Toggle;
    }

    private void OnDisable()
    {
        InputManager.Onpause -= Toggle;
    }

    private void Start()
    {
        
    }

    private void Toggle(bool pressed)
    {
        

        if (pressed)
        { 

            if(isPressed == true)
            {
                Time.timeScale = 0;
                isPressed = false;
                volume.Value = 0.5f;
                
               
                
                
            }
            else if(isPressed == false)
            {
                Time.timeScale = 1;
                isPressed = true;

                volume.Value =1f;
                


            }
        }
        
    }

   

}
