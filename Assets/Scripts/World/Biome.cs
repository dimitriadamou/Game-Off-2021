using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {

[CreateAssetMenu(fileName = "Biome", menuName = "World/Biome", order = 0)]
public class Biome : ScriptableObject {
    public string Name;

    public List<EnemyController> prefabSpawner;
    public GroundTileBehaviour groundTile;
    public List<ObstacleData> obstacleData;
    public List<WaterTileBehaviour> waterTile;
    public List<SpawnerData> spawners;
    public List<EnemyData> enemies;

    public float spawnMinY;
    public float spawnMaxY;

    public float minUnits = 300;
    public float maxUnits = 400;
}
    
}