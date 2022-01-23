using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;
    public GameObject pointObj;//测试
    CharacterControl characterControl;

    public int bloodValue;

    PlayerAnimatorControl playerAnimatorControl;
    int groundMask = 0;
    [Range(0, 1)]
    public float speedScale = 0.6f;//最低速度占比标准速度
    bool isMouse0 = false;
    Quaternion cameraVec;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        groundMask = 1 << LayerMask.NameToLayer("Ground");
        characterControl = GetComponent<CharacterControl>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
        cameraVec = Camera.main.transform.rotation;
        this.bloodValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //ClickPoint();
        MoveControl();
        AttackControl();
    }
    void ClickPoint()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, groundMask))
            {
                Instantiate(pointObj, hit.point, Quaternion.identity);
                //characterControl.SetPos(hit.point);
            }
        }
    }

    void MoveControl()
    {
        isMouse0 = false;
        Vector3 mouseDir = Vector3.zero;//一个y轴为0的向量
        if (Input.GetMouseButton(1))
        {
            isMouse0 = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, groundMask))
            {
                Vector3 pos = hit.point;
                pos.y = transform.position.y;
                mouseDir = pos - transform.position;
                characterControl.SetDir(mouseDir);
            }
        }

        Vector3 vecSpeed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (vecSpeed.sqrMagnitude > 0)
        {
            float scale = 1f;
            float dirDot = Vector3.Dot(mouseDir.normalized, vecSpeed.normalized);
            Vector3 dirCross = Vector3.Cross(mouseDir.normalized, vecSpeed.normalized);

            if (isMouse0)
            {
                playerAnimatorControl.SetMove(new Vector2(dirCross.y, dirDot));
                scale = (0.5f - speedScale * 0.5f) * dirDot + (0.5f * speedScale + 0.5f) * scale;
            }
            else
            {
                playerAnimatorControl.SetMove(new Vector2(0, vecSpeed.magnitude));
                characterControl.SetDir(vecSpeed);
            }
            characterControl.SetSpeed(vecSpeed, characterControl.speedValue * scale);
        }
        else
        {
            playerAnimatorControl.SetMove(Vector2.zero);
        }
    }
    public Transform fightPoint;
    public GameObject bullet;
    float addTime = 0;
    public float flghtIntervalTime = 0.5f;
    void AttackControl()
    {
        if (Input.GetMouseButton(0))
        {
            if (addTime >= flghtIntervalTime)
            {
                addTime = 0;
            }
            if (addTime == 0)
            {
                Instantiate(bullet, fightPoint.position, fightPoint.rotation)
                .GetComponent<IBallisticSet>()
                .SetActive(true);
            }
        }
        addTime += Time.deltaTime;
        if (addTime >= flghtIntervalTime)
        {
            addTime = flghtIntervalTime;
        }
    }

}

