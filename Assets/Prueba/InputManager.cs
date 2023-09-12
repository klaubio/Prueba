using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   public static event System.Action<bool> Onpause;
   public static event System.Action Jump;
   public static event System.Action<float> OnPlayerMovement;


    [SerializeField] private PlayerInput playerinput;



    private void OnEnable()
    {
        playerinput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerinput.onActionTriggered -= HandleInput;
    }




    public void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {

            case "Movimiento":

                float input = context.ReadValue<float>();
                OnPlayerMovement?.Invoke(input);
                Debug.Log(input);
                break;

            case "Pause":
                
                if(context.started)Onpause.Invoke(true);
                else if(context.canceled)Onpause?.Invoke(false);
                break;
           
            case "Jump" :
                if(context.started)Jump.Invoke();
                Debug.Log(Jump);
                break;
          
        }

    }









}
