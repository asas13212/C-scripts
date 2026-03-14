using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Test : MonoBehaviour
{
    [SerializeField] _Test t;
    [Header("移动速度")] [Range(-10, 20)] public float speed = 1f;
    [SerializeField] public bool moveForward;
    [SerializeField] public double distance = 10.0;
    private void Update()
    {
        //Vector3 pos = this.gameObject.transform.position;
        if( moveForward)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime*speed ,Space.World);
        }
        else
        {
            this.transform.Translate(Vector3.left * Time.deltaTime*speed);
        }
        
        if( Vector3.Distance(t.transform.position,gameObject.transform.position) <= distance)
        {
            t.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            t.transform.Translate(Vector3.back * Time.deltaTime);
        }
    }


}
