using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {

[CreateAssetMenu(fileName = "Biome", menuName = "World/Biome", order = 0)]
public class Biome : ScriptableObject {
    public string Name;
    public GroundTileBehaviour groundTile;
    public List<ObstacleData> obstacleData;
    public List<WaterTileBehaviour> waterTile;
    public float minUnits = 300;
    public float maxUnits = 400;
}
    
}