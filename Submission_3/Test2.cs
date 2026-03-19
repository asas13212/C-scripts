using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Vector3 v = Input.mousePosition;
        v.z = 10.0f; 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = Camera.main.ScreenToWorldPoint(v);
        }
    }
}
