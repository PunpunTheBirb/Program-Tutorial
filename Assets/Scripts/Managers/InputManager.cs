using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class InputManager
{
   
   private static Controls _controls;


   public static void Init(Player myPlayer)
   {

   _controls = new Controls();

      //When the inputs within Movement are preformed read direction and move that way
    _controls.Game.Movement.performed += hi => 
    { 
          myPlayer.SetMovementDirection(hi.ReadValue<Vector3>());
    };
      //When the input for Jump is pressed read it and travel up
     _controls.Game.Jump.performed += hi => 
    { 
          myPlayer.SetMovementDirection(hi.ReadValue<Vector2>());
    };
      //When inputing Crouch say Crouch in log
      _controls.Game.Crouch.performed += hi => 
    { 
          Debug.Log("Crouch");
    };
    //When inputing Shoot say Shoot
    _controls.Game.Shoot.performed += hi => 
    { 
          Debug.Log("Shoot");
    };

    _controls.Permanent.Enable();
    
   }

   public static void GameMode()
   {
        _controls.Game.Enable();
        _controls.UI.Disable();
   }

   public static void UIMode()
   {
        _controls.UI.Enable();
        _controls.Game.Disable();
   }
}
