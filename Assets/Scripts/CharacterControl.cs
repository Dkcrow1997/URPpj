using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speedValue = 2;
    public float turnSpeed = 360;
    Vector3 pos;
    bool isMove = false;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.SimpleMove(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            pos.y = transform.position.y;
            Vector3 speedVec = pos - transform.position;
            SetDir(speedVec);
            if (speedVec.magnitude > 0.01)
            {
                characterController.SimpleMove(speedVec.normalized * speedValue);
            }
            else
            {
                isMove = false;
            }

        }
    }

    private void LateUpdate() {
        //Debug.Log(characterController.velocity.magnitude);
    }

    public void SetDir(Vector3 dir)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
    }

    public void SetPos(Vector3 pos)
    {
        this.pos = pos;
        isMove = true;
    }

    public void SetSpeed(Vector3 speedVec,float speed = 5.5f)
    {
        speedVec = speedVec.normalized + new Vector3(0, transform.position.y, 0);
        characterController.SimpleMove(speedVec * speed);
    }
}
