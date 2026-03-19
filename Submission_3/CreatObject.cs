using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatObject : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool createOnStart = true;
    [SerializeField] Vector3 localSpawnPos = new Vector3(-1, 0, 1);

    GameObject cube;

    void Start()
    {
        if (createOnStart)
            CreateCubeAtLocal(localSpawnPos);
    }

    void Update()
    {
        // 平滑朝当前物体的 forward 方向移动（世界空间）
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // 示例：按空格键创建（如果还没创建）
        if (Input.GetKeyDown(KeyCode.Space) && cube == null)
            CreateCubeAtLocal(localSpawnPos);
    }

    void CreateCubeAtLocal(Vector3 localPos)
    {
        // 只创建一次
        if (cube != null) return;

        // 创建一个立方体并放到相对于该物体的 localPos 的世界位置
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "Cube";
        cube.transform.position = transform.TransformPoint(new Vector3(-1,0,1));
    }
}
