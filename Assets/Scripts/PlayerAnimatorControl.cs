using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorControl : MonoBehaviour
{
    public Animator animator;

    public void SetMove(Vector2 move)
    {
        animator.SetFloat("H", move.x);
        animator.SetFloat("V", move.y);
    }

}
