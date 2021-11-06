using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {
    
[CreateAssetMenu(fileName = "EnemyData", menuName = "World/Enemy Data", order = 0)]
public class EnemyData : ScriptableObject {
    public NPCBehaviour npcBehaviour;

}

}