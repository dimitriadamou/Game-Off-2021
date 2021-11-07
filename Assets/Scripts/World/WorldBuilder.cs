using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld {

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] WorldData worldData;
    [SerializeField] SharedVector3 playerLocation;

    [SerializeField] GameObject worldObject;

    [SerializeField] GameObject containerPrefab;
    private List<GameObject> containers;
    
    float unitWidth = 7;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(buildWorld());
    }
    

    IEnumerator buildWorld()
    {
        //worldData.biomes[0];
        var currentBiome = worldData.biomes[0];

        var maxY = Random.Range((int)currentBiome.minUnits, (int)currentBiome.maxUnits);

        GameObject container = null;

        var obstacleData = currentBiome.obstacleData;
        int i = 0;


        for(int y = 0; y <= maxY; y += 3) {

            if(y % 18 == 0) {
                container = GameObject.Instantiate(
                    containerPrefab,
                    new Vector3(
                        0,0,0
                    ),
                    Quaternion.identity,
                    worldObject.transform
                );

                container.transform.localPosition = new Vector3(
                    0,
                    y,
                    0f
                );
            }

            float occupiedSlots = 0f;

            for(int x = -9; x <= 9; x += 3) {
                i = 0;
                
                //Random.Range(0f, 1f);

                foreach (var item in obstacleData)
                {
                    var rnd = Random.Range(0f, 1f);

                    if(rnd < item.frequency) {
                        
                        occupiedSlots += item.slots;

                        var obstacleObj = GameObject.Instantiate(
                            item.obstaclePrefab,
                            Vector3.zero,
                            Quaternion.identity,
                            container.transform
                        );

                        obstacleObj.transform.localPosition = new Vector3(
                            (float)Random.Range(
                                x,
                                x + 3
                            ),
                            (float)y % 18,
                            -1
                        );

                        i++;
                        break;

                    }
                }

                var gObj = GameObject.Instantiate(
                    currentBiome.groundTile,
                    new Vector3(
                        0,
                        0,
                        0
                    ),
                    Quaternion.identity,
                    container.transform
                );

                

                gObj.transform.localPosition = new Vector3(
                    (float)x,
                    (float)y % 18,
                    0f
                );
            }

            yield return new WaitForEndOfFrame();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}