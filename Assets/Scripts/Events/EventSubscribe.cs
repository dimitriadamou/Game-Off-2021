using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSubscribe", menuName = "Events/Event Subscribe", order = 0)]
public class EventSubscribe : ScriptableObject {
    public UnityEngine.Events.UnityAction Callback;
}