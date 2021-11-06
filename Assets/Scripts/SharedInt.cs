using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SharedInt", menuName = "Variables/Shared Int", order = 0)]
public class SharedInt : ScriptableObject {
    private int _value = 0;
    
    public UnityEngine.Events.UnityAction<int> Callback = delegate {};

    public int Value
    {
        set {
            _value = value;
            Callback.Invoke(value);
        }
        get { 
            return _value;
        }
    }   
}