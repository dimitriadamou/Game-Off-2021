using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SharedVector3", menuName = "Variables/Shared Vector3", order = 0)]
public class SharedVector3 : ScriptableObject {
    private Vector3 v3;
    public event UnityAction <Vector3> Callback = delegate {};
    
    public Vector3 Value {
        get {
            return v3;
        }
        set {
            v3 = value;
        }
    }

    
}