using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leeson4 : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "3";
        print(this.gameObject.name);
        print(this.gameObject.tag);
        this.gameObject.tag = "Player";
         print(this.gameObject.tag);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cube1 = GameObject.FindWithTag("222");
        //cube1.gameObject.SetActive(false);
        GameObject cube2 = GameObject.FindWithTag("222");
        if(cube2 != null)
        {
            print("找到物体了");
        }
        GameObject.Instantiate(car);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
