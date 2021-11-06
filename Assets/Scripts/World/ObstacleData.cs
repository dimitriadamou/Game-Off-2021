using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyWorld {
[CreateAssetMenu(fileName = "ObstacleData", menuName = "World/ObstacleData", order = 0)]
public class ObstacleData : ScriptableObject {
    public ObstacleObject obstaclePrefab;
    public float frequency = 0.1f;
    public float slots = 1f;
}

}
