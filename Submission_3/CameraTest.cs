using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform sphere;
    // Update is called once per frame
    void Update()
    {
        Vector3 v = Camera.main.WorldToScreenPoint(Input.mousePosition);
        v.z  = 10;
        sphere.position = Camera.main.ScreenToWorldPoint(v);
    }
}
