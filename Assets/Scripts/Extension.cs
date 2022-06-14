using UnityEngine;

public static class Extension
{
    public static Vector3 ToXZPlainNormalVector(this Vector3 orig)
    {
        orig.y = 0;
        return orig.normalized;
    }

    public static float AngleBetweenVectors(this Vector3 orig, Vector3 target)
    {
        return Mathf.Acos(Vector3.Dot(orig, target));
    }

    public static bool IsAngleBetweenVectorsLessThanGiven(this Vector3 orig, Vector3 target, float given)
    {
        return orig.AngleBetweenVectors(target) * Mathf.Rad2Deg < given;
    }
}