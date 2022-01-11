using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAniController : MonoBehaviour
{
    public Animator humanAnimator;


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
                Debug.Log("PerformedControlJump");
            }, 
            (InputAction.CallbackContext obj) => 
            {
                Debug.Log("CancelControlJump");
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
        humanAnimator.SetFloat("x", vec2.x * 2);
        humanAnimator.SetFloat("y", vec2.y * 2);
    }

    public void CancelControlMove(InputAction.CallbackContext obj)
    {
        Debug.Log("CancelControlMove");
        humanAnimator.SetFloat("x", 0);
        humanAnimator.SetFloat("y", 0);
    }
}
