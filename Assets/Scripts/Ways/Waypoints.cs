using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waypoints : MonoBehaviour {

    public static Transform[] positions;
    public LineRenderer line;

    void Awake()
    {
        positions = new Transform[transform.childCount];
        line.positionCount = positions.Length;
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
            line.SetPosition(i, positions[i].position);
        }
    }

}
