using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GroundInfo
{
    private float distance;
    private float angle;
    private string tag;

    private Vector3 normal;

    public GroundInfo(float distance, float angle, string tag, Vector3 normal)
    {
        this.distance = distance;
        this.angle = angle;
        this.tag = tag;
        this.normal = normal;
    }

    public float Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public float Angle
    {
        get { return angle; }
        set { angle = value; }
    }

    public string Tag
    {
        get { return tag; }
        set { tag = value; }
    }

    public Vector3 Normal
    {
        get { return normal; }
        set { normal = value; }
    }
}
