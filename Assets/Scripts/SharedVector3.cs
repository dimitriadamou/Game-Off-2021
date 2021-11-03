using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SharedVector3", menuName = "Variables/SharedVector3", order = 0)]
public class SharedVector3 : ScriptableObject {
    private Vector3 v3;
    
    public Vector3 Value {
        get {
            return v3;
        }
        set {
            v3 = value;
        }
    }

    
}