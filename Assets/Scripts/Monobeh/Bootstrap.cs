using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = new Vector3(1, 2, 3);
        vec = vec.SetX(10);
        transform.SetPositionX(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
