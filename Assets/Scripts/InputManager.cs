using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    public static CustomInput input;
    public static Vector2 navigationAxis => input.Player.Movement.ReadValue<Vector2>(); 

    static InputManager()
    {
        input = new CustomInput();
        input.Enable();
    }
}
