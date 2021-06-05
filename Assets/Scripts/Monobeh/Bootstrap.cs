using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    void Start()
    {
        Vector3 vec = new Vector3(1, 2, 3);
        vec = vec.SetX(10);
        transform.SetPositionX(10);
    }

    void Update()
    {
        
    }
}
