using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSun : MonoBehaviour
{

    public Transform zero;
    [SerializeField] [Range(0,200)] float rotationSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(zero.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
