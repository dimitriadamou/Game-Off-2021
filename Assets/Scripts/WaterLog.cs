using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLog : MonoBehaviour
{
    [SerializeField] List<GameObject> LogPrefabs;
    // Start is called before the first frame update
    List<GameObject> spawnedLogs;

    
    void Start()
    {
        //this.transform.localScale.x;

        spawnedLogs = new List<GameObject>();

        foreach(var item in LogPrefabs) {
            var log = GameObject.Instantiate(
                item,
                Vector3.zero,
                Quaternion.identity,
                this.transform
            );

            log.SetActive(false);
            
            spawnedLogs.Add(log);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
