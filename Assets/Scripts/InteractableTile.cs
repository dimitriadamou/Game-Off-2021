using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteractableTile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EventSubscribe OnTileEnter;

    [SerializeField] EventSubscribe OnTileExit;
    
    [SerializeField] SharedVector3 playerLocation;

    private bool entered = false;

    private float getMinYPos()
    {
        return playerLocation.Value.y - (this.transform.position.y - (this.transform.localScale.y / 2));
    }

    private float getMaxYPos()
    {
        return playerLocation.Value.y - (this.transform.position.y + (this.transform.localScale.y / 2));
    }

    private float getMinZPos()
    {
        return playerLocation.Value.z - (this.transform.position.z - (this.transform.localScale.z / 2));
    }

    private float getMaxZPos()
    {
        return playerLocation.Value.z - (this.transform.position.z + (this.transform.localScale.z / 2));
    }

    private float getMinXPos()
    {
        return playerLocation.Value.x - (this.transform.position.x - (this.transform.localScale.x / 2));
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            this.transform.position - new Vector3(
                this.transform.localScale.x / 2,
                -this.transform.localScale.y / 2,
                0f
            ),            
            this.transform.position + new Vector3(
                this.transform.localScale.x / 2,
                this.transform.localScale.y / 2,
                0f
            )            
        );

        Gizmos.DrawLine(
            this.transform.position - new Vector3(
                this.transform.localScale.x / 2,
                this.transform.localScale.y / 2,
                0f
            ),            
            this.transform.position + new Vector3(
                this.transform.localScale.x / 2,
                -this.transform.localScale.y / 2,
                0f
            )            
        );
    }

    private float getMaxXPos()
    {
        return playerLocation.Value.x - (this.transform.position.x + (this.transform.localScale.x / 2));
    }


    // Update is called once per frame
    float logMS;
    void Update()
    {
        logMS += Time.deltaTime;

        if(logMS >= 1f) {
            logMS = 0f;
            Debug.Log(
                getMinYPos() + " > 0 < " + getMaxYPos()
            );
        }

        if(
            getMinYPos() > 0 && getMaxYPos() < 0 &&
            getMinXPos() > 0 && getMaxXPos() < 0 &&
            getMinZPos() > 0 && getMaxZPos() < 0
        ) {
            if(!entered) {

                Debug.Log(
                    getMinYPos() + " > 0 < " + getMaxYPos()
                );
                                
                OnTileEnter?.Callback.Invoke();
                Debug.Log("callback invoked.");
                entered = true;
            }
        } else {
            if(entered) {
                OnTileExit?.Callback.Invoke();
                entered = false;
            }
        }
    }
}
