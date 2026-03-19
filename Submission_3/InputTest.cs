
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputTest : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30f)] float moveSpeed = 5f;
    [SerializeField][Range(1f, 360f)] float turnSpeed = 120f; // 坦克转向速度（度/秒）
    [SerializeField][Range(1f, 360f)] float turretTurnSpeed = 200f; // 炮台转速（度/秒）

    [Header("拖入炮台 Transform（通常是车体的子对象））")]
    public Transform turret;

    [Header("炮台左右最大偏移角度（相对于初始局部 Y）")]
    [SerializeField] float maxYaw = 45f;

    // 内部状态
    float initialYaw = 0f;
    float currentYaw = 0f;

    void Start()
    {
        if (turret != null)
        {
            initialYaw = NormalizeAngle(turret.localEulerAngles.y);
            currentYaw = initialYaw;
        }
    }

    void Update()
    {
        // 获取输入
        float forward = Input.GetAxis("Vertical");    // W/S 或 上/下
        float turn = Input.GetAxis("Horizontal");     // A/D 或 左/右
        float mouseX = Input.GetAxis("Mouse X");      // 鼠标水平移动

        // 坦克 前后 移动（沿本地 forward）
        if (Mathf.Abs(forward) > 0.0001f)
        {
            transform.Translate(Vector3.forward * forward * moveSpeed * Time.deltaTime, Space.Self);
        }

        // 坦克 转向（绕自身 Y 轴）
        if (Mathf.Abs(turn) > 0.0001f)
        {
            transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime, Space.Self);
        }

        // 炮台左右转（仅绕 Y 轴），并限制在 initialYaw ± maxYaw
        if (turret != null && Mathf.Abs(mouseX) > 0.00001f)
        {
            // 增量累加
            currentYaw += mouseX * turretTurnSpeed * Time.deltaTime;
            // clamp 到初始角度的范围
            currentYaw = Mathf.Clamp(currentYaw, initialYaw - maxYaw, initialYaw + maxYaw);
            // 应用到 localEulerAngles（保持 X,Z 不变）
            Vector3 le = turret.localEulerAngles;
            float x = le.x;
            float z = le.z;
            turret.localEulerAngles = new Vector3(x, currentYaw, z);
        }
    }

    // 把 0..360 的角度规范到 -180..180
    static float NormalizeAngle(float a)
    {
        return Mathf.Repeat(a + 180f, 360f) - 180f;
    }
}