using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Header("移动速度")] [Range(-20,20)] double moveSpeed;
    [SerializeField] [Header("转动")] [Range(-180, 180)] double rotationEularAngeles = 0;
    [SerializeField] [Header("是否展示自己")] bool showSelf = false;
    [SerializeField] [Header("回到展示位置速度")] [Range(0.1f, 20f)] float returnSpeed = 5f;

    public Transform position;
    private Vector3 lastPosition;
    [SerializeField] Transform player;
    private float rotateSpeed = 20f;
    // 支持被展示前的位置，用于展示结束后回到此位置
    private Vector3 originalPosition;
    // 状态跟踪
    private bool returning = false;
    private bool wasShowing = false;
    public bool open = false;
    // Update is called once per frame

    private void Start()
    {   
        lastPosition = this.transform.position;
        originalPosition = lastPosition;
    }
    void Update()
    {   
        if (open)
        {
            player.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (showSelf)
        {
            // 刚开始进入展示状态时保存当前位置（用于返回）
            if (!wasShowing)
            {
                originalPosition = this.transform.position;
                wasShowing = true;
                returning = false;
            }

            // 传送到展示台上（带高度偏移）
            Vector3 targetPos = position.position + Vector3.up * 0.41f;
            if (this.transform.position != targetPos)
            {
                this.transform.position = targetPos;
            }

            // 绕自己转动
            if (rotationEularAngeles == 0) rotationEularAngeles = 20;
            this.transform.Rotate(Vector3.up * Time.deltaTime * (float)rotationEularAngeles);
        }
        else
        {
            // 从展示状态退出：开始返回原位
            if (wasShowing)
            {
                returning = true;
                wasShowing = false;
            }

            if (returning)
            {
                // 平滑返回到 originalPosition
                this.transform.position = Vector3.MoveTowards(this.transform.position, originalPosition, Time.deltaTime * returnSpeed);

                // 返回完成
                if (Vector3.Distance(this.transform.position, originalPosition) <= 0.001f)
                {
                    this.transform.position = originalPosition;
                    returning = false;
                    // 可选：重置 lastPosition
                    lastPosition = originalPosition;
                }
            }
            else
            {
                // 非展示且不在返回过程中的常规移动行为
                this.transform.Translate(Vector3.back * Time.deltaTime * (float)moveSpeed);
                // 绕自己转动（以世界空间为轴）
                this.transform.Rotate(Vector3.up * Time.deltaTime * (float)rotationEularAngeles, Space.World);
                lastPosition = this.transform.position;
            }
        }
    }
}
