using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public List<NPCBehaviour> NPCPrefabs;
    [SerializeField] public float Count = 1f;
    [SerializeField] public float SpacingUnits = 0f;
    [SerializeField] public List<Route> NPCPath;
    [SerializeField] SharedVector3 playerLocation;

    private List<NPCBehaviour> myNPCs;
    // Start is called before the first frame update
    float lastAlpha = -1f;

    private float getYPos()
    {
        return playerLocation.Value.y - this.transform.position.y;
    }

    void ProcessAlpha()
    {
        var yPos = getYPos();
        var distance = Mathf.Clamp(
            Mathf.Abs(yPos),
            10f,
            15f
        );

        float alpha = Mathf.Lerp(
            0f,
            yPos < 0 ? 1f : 1f,
            yPos < 0 ? 1f - ((distance - 10f) / 5f) : 1f
        );


        if(!Mathf.Approximately(
            alpha, lastAlpha
        )) {
            foreach (var item in myNPCs)
            {
                item.setAlpha(alpha);
                item.setScale(alpha);
            }
            lastAlpha = alpha;
        }
    }

    void Start()
    {
        var startX = NPCPath[0].Routes[0].x;

        myNPCs = new List<NPCBehaviour>();

        for (int i = 0; i < Count; i++)
        {
            var npc = GameObject.Instantiate(
                NPCPrefabs[i % NPCPrefabs.Count],
                transform.position,
                transform.rotation
            );

            npc.CurrentRoute = NPCPath[0];

            npc.transform.SetParent(this.transform);

            npc.transform.localPosition = new Vector3(
                i * SpacingUnits,
                0f,
                0f
            );

            myNPCs.Add(npc);
        }

        ProcessAlpha();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        ProcessAlpha();
        
        if(Mathf.Clamp(Mathf.Abs(getYPos()), 10, 15) >= 15) return;

        foreach (var item in myNPCs)
        {
            item.ProcessRoute(deltaTime);
        }
    }
}
