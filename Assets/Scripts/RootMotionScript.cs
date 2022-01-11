using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class RootMotionScript : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorMove()
    {


        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = animator.GetFloat("jumphight");
            transform.position = newPosition;
        }
    }
}