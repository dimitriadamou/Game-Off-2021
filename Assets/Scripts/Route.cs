using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Route", menuName = "Definitions/Route", order = 0)]
public class Route : ScriptableObject {
    public List<Vector3> Routes;
    public List<float> RouteRate;
}