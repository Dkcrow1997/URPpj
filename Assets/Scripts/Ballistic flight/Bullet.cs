using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBallisticSet
{
    void SetActive(bool isActive);
    void SetTraget(GameObject obj);
}

public enum BulletType
{
    Normal = 0,
    Follow = 1,
}

public class Bullet : MonoBehaviour, IBallisticSet
{
    [HideInInspector]
    private bool isActive = false;//激活
    [HideInInspector]
    private GameObject target;
    [HideInInspector]
    private float realMoveSpeed = 5;
    [HideInInspector]
    private float realTurnSpeed = 5;

    public BulletType bulletType = BulletType.Normal;

    public float lifeTime = 2f;

    public float moveSpeed = 30;
    public AnimationCurve moveSpeedCurve;

    public float turnSpeed = 30;
    public AnimationCurve turnSpeedCurve;

    public float timeValue;

    Quaternion tragetQua;
    Vector3 tragetVec;

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;
    }

    public void SetTraget(GameObject obj)
    {
        this.target = obj;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (this.isActive)
        {
            timeValue += Time.deltaTime;
            float Move_Speed = turnSpeedCurve.Evaluate(timeValue) * moveSpeed;
            float Turn_Speed = turnSpeedCurve.Evaluate(timeValue) * turnSpeed;
            switch (bulletType)
            {
                case BulletType.Normal:
                    transform.Translate(transform.forward * Move_Speed * Time.deltaTime, Space.World);
                    break;
                case BulletType.Follow:
                    tragetVec = target.transform.position - transform.position;
                    tragetQua = Quaternion.LookRotation(tragetVec);//在空中使用自身坐标transform.up 在地面是世界坐标up 
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, tragetQua, Turn_Speed * Time.deltaTime);
                    transform.Translate(transform.forward * Move_Speed * Time.deltaTime, Space.World);
                    break;
            }
        }
    }
}
