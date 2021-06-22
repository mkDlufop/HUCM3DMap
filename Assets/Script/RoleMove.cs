using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMove : MonoBehaviour
{
    // CharacterController controller; // 声明角色控制器
    // public float speed = 6.0f; // 定义角色的移动速度
    // public float rotateSpeed = 3.0f; // 定义角色的转身速度
    // Rigidbody rigid; // 声明一个刚体的成员变量
    private Transform m_Transform;                              //Transform
    private Animator m_Animator;                                //动画组件
    private CharacterController m_CC;                           //角色控制器组件
    private Rigidbody m_Rigidbody;                              //Rigidbody组件
    private CapsuleCollider m_CapsuleCollider;                  //胶囊碰撞体。不使用人物控制器时，使能胶囊碰撞体。

    private Camera playerCamera;                                //人物摄像机
    private CameraController playerCameraScript;                //人物摄像机脚本（第三人称）

    private float h = 0;                    //A D键输入
    private float v = 0;                    //W S键输入

    private bool isRun = false;             //是否奔跑
    private float walkSpeed_Third = 0.01f;  //行走速度
    //private float runSpeed_Third = 0.1f;  //奔跑速度。  //当前动画默认是会移动的，所以速度已经提升

    void Start()
    {
        // controller = this.GetComponent<CharacterController>(); // 获取角色的控制器组件
        // rigid = GetComponent<Rigidbody>(); // 获取刚体的引用
        FindInit();

        SetPlayerControllerMode();
    }

    void Update()
    {
        // 按左右键控制角色移动
        // transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0)); 
        // Vector3 forward = transform.TransformDirection(Vector3.forward); 
        // 按上下键控制角色移动
        // controller.SimpleMove(forward * speed * Input.GetAxis("Vertical"));

        // 前后左右移动物体
        // var h = Input.GetAxis("Horizontal"); // GetAxis()返回轴的值，处于-1~1之间
        // var v = Input.GetAxis("Vertical");
        // rigid.AddForce(Vector3.right * h + Vector3.forward * v); // 给刚体一个作用力

        // Debug.Log("h:" + h);
        // Debug.Log("v:" + v);
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //控制虚拟人物移动
        MoveUpdate_ThirdController();
    }
    
    // 查找初始化
    private void FindInit()
    {
        // 获取组件
        m_Transform = gameObject.GetComponent<Transform>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_CC = gameObject.GetComponent<CharacterController>();
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_CapsuleCollider = gameObject.GetComponent<CapsuleCollider>();

        playerCamera = Camera.main;

        playerCameraScript = playerCamera.GetComponent<CameraController>();
    }

    /// 设置人物控制模式.
    public void SetPlayerControllerMode()
    {
        if (!m_CC.enabled) m_CC.enabled = true;
        if (!m_Rigidbody.useGravity) m_Rigidbody.useGravity = true;
        if (m_CapsuleCollider.enabled) m_CapsuleCollider.enabled = false;

        playerCameraScript.enabled = true;

        playerCamera.transform.SetParent(m_Transform.parent, false);
        playerCamera.transform.localPosition = new Vector3(0, m_Transform.localPosition.y + 2.2f, m_Transform.localPosition.z - 2.2f); //摄像机跳到人物后上方。低于人物，视角会判断异常。
        playerCamera.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    // 第三人称。人物移动操作
    private void MoveUpdate_ThirdController()
    {
        // 按住左SHIFT 加速.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        //按下 W A S D或者上下左右方向键。
        if (v != 0 || h != 0)
        {
            if (isRun)  // 执行奔跑动画
            {
                m_Animator.SetBool("Run", true);
            }
            else        // 执行行走动画
            {
                m_Animator.SetBool("Run", false);
                m_Animator.SetBool("Walk", true);
            }

            float rotY = playerCamera.transform.rotation.eulerAngles.y;     // 摄像机世界坐标前方
            Vector3 dir = new Vector3(h, 0, v);                             // 移动方向
            dir = Quaternion.Euler(0, rotY, 0) * dir;                       // 移动方向的前方为摄像机前方.（按下W，向摄像机正前方行走）（前进方向必须是摄像机的前方）

            //m_CC.SimpleMove(dir);
            m_CC.Move(dir * walkSpeed_Third);
            m_Transform.localRotation = Quaternion.LookRotation(dir);
        }
        else
        {
            m_Animator.SetBool("Walk", false);
        }
    }
}
