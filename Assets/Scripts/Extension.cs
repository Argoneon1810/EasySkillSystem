using UnityEngine;

public static class Extension
{
    public static Vector3 ToXZPlainNormalVector(this Vector3 orig)
    {
        orig.y = 0;
        return orig.normalized;
    }
}