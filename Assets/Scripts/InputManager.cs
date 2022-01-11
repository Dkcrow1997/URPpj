using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;
    public PlayerController PlayerController => playerController;
    public static InputManager Instance;
    private void Awake()
    {
        Instance = this;
        playerController = new PlayerController();
    }


    private void OnEnable()
    {
        playerController.Enable();
    }


    public void AddMoveEvent(InputAction tragetAction, System.Action<InputAction.CallbackContext> startedCallback, System.Action<InputAction.CallbackContext> performedCallback, System.Action<InputAction.CallbackContext> canceledCallback)
    {
        if (performedCallback != null) tragetAction.performed += performedCallback;
        if (canceledCallback != null) tragetAction.canceled += canceledCallback;
        if (startedCallback != null) tragetAction.started += startedCallback;
    }

    private void OnDisable()
    {
        playerController.Disable();
    }
}
