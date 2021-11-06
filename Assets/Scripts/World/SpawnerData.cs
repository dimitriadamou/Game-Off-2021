using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "World/Spawner Data", order = 0)]
    public class SpawnerData : ScriptableObject {
        public List<Route> routes;
    }

}