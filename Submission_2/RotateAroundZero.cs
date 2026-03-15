using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundZero : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(Vector3.zero,Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
