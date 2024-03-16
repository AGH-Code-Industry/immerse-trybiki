using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    public static CustomInput input;
    public static Vector2 navigationAxis => input.Player.Movement.ReadValue<Vector2>();
    public static Vector2 MousePosition => GetMouseWorldPosition();

    static InputManager()
    {
        input = new CustomInput();
        input.Enable();
    }

    private static Vector2 GetMouseWorldPosition()
    {
        if (Camera.main is not null)
        {
            return Camera.main.ScreenToWorldPoint(MousePosition);
        }
        throw new Exception(
                "Tried to access CInput.MouseWorldPosition with no object with tag 'MainCamera' present in the loaded scenes.");
    }
}
