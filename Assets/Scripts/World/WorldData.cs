using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {

[CreateAssetMenu(fileName = "WorldData", menuName = "World/World Data", order = 0)]
public class WorldData : ScriptableObject {
    public List<Biome> biomes;
}

}
