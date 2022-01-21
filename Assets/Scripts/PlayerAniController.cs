using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAniController : MonoBehaviour
{
    public Animator humanAnimator;

    private void Awake()
    {
        humanAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        InputManager.Instance.AddMoveEvent(InputManager.Instance.PlayerController.Player.Move, StartControlMove, PerformedControlMove, CancelControlMove);
        InputManager.Instance.AddMoveEvent(InputManager.Instance.PlayerController.Player.Jump, 
            (InputAction.CallbackContext obj) => 
            {
                Debug.Log("StartControlJump");
                humanAnimator.SetTrigger("jump");
            }, 
            (InputAction.CallbackContext obj) => 
            {
                Debug.Log("PerformedControl Jump");
            }, 
            (InputAction.CallbackContext obj) => 
            {
                Debug.Log("CancelControl Jump");
            });
        InputManager.Instance.AddMoveEvent(InputManager.Instance.PlayerController.Player.Fire,
            (InputAction.CallbackContext obj) =>
            {
                 Debug.Log("StartControl Fire");
            },
            (InputAction.CallbackContext obj) =>
            {
                Debug.Log("PerformedControl Fire");
            },
            (InputAction.CallbackContext obj) =>
            {
                Debug.Log("CancelControl Fire");
            });
        InputManager.Instance.AddMoveEvent(InputManager.Instance.PlayerController.Player.Fire1,
            (InputAction.CallbackContext obj) =>
            {
                Debug.Log("StartControl Fire1");
            },
            (InputAction.CallbackContext obj) =>
            {
                Debug.Log("PerformedControl Fire1");
            },
            (InputAction.CallbackContext obj) =>
            {
                Debug.Log("CancelControl Fire1");
            });
    }
    public void StartControlMove(InputAction.CallbackContext obj)
    {
        Debug.Log("StartControlMove");
    }
    public void PerformedControlMove(InputAction.CallbackContext obj)
    {
        Debug.Log("PerformedControlMove");
        Vector2 vec2 = obj.ReadValue<Vector2>();
        humanAnimator.SetFloat("x", vec2.x * 1);
        humanAnimator.SetFloat("y", vec2.y * 1);
    }

    public void CancelControlMove(InputAction.CallbackContext obj)
    {
        Debug.Log("CancelControlMove");
        humanAnimator.SetFloat("x", 0);
        humanAnimator.SetFloat("y", 0);
    }
}
