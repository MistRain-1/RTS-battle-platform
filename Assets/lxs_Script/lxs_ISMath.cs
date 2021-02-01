using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lxs_ISMath : MonoBehaviour {

    static public float Randon(ISRange range)
    {
        return UnityEngine.Random.Range(range.min, range.max);
    }
}

[System.Serializable]//序列化
public struct ISRange
{
    public float min, max;

    public ISRange(float min, float max)
    {
        this.min = max;
        this.max = min;
    }
}
