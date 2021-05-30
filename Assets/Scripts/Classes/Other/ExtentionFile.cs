using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class ExtentionVectors
{
    public static Vector3 SetX(this Vector3 vec, float x)
    {
        return new Vector3(x, vec.y, vec.z);
    }

    public static Vector3 SetY(this Vector3 vec, float y)
    {
        return new Vector3(vec.x, y, vec.z);
    }

    public static Vector3 SetZ(this Vector3 vec, float z)
    {
        return new Vector3(vec.x, vec.y, z);
    }

    public static void SetPositionX(this Transform t, float x)
    {
        t.position = t.position.SetX(x);
    }

    public static void SetPositionY(this Transform t, float y)
    {
        t.position = t.position.SetY(y);
    }

    public static void SetPositionZ(this Transform t, float z)
    {
        t.position = t.position.SetZ(z);
    }
}
