using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(-20,20)] float moveSpeed = 5f;
    [SerializeField] [Range(-200,200)] float turnSpeed = 150f;
    [SerializeField] [Range(-45,45)] float turnEularAngle = 45f;
    //Screen 
    public Transform turret;
    public Transform firePoint;
    void Start()
    {
            
    }
    // Update is called once per frame
    void Update()
    {
        float f = Input.GetAxis("Vertical");
        float t = Input.GetAxis("Horizontal");
        // 前后移动，坦克沿着自身的 forward 方向移动
        this.transform.Translate( new Vector3 ( 0, 0, f) * moveSpeed * Time.deltaTime);
        // 转向，坦克绕着自身的 Y 轴旋转
        this.transform.Rotate( new Vector3 (0, t, 0) * turnSpeed * Time.deltaTime);
        // 炮台转向
        turret.Rotate(new Vector3(0,  0,Input.GetAxis("Mouse X") * turnSpeed));
        if (Input.mouseScrollDelta.y == 1)
        {
            firePoint.Rotate(new Vector3(Input.GetAxis("Mouse Y") * turnSpeed, 0, 0));
        }
    }

   
}
