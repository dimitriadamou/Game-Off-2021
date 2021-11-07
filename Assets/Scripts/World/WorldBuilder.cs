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

            for(int x = -9; x <= 9; x += 3) {
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