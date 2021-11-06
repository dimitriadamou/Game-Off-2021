using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SharedVector3 playerLocation;
    [SerializeField] List<SpriteRenderer> spriteRenderer;
    Vector3 originalPosition;
    Vector3 originalPositionNoZ;
    Vector3 targetPosition;

    private float alpha = 0f;
    private float lastAlpha = 0f;
    void Start()
    {
        targetPosition = originalPosition = transform.localPosition;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            -30
        );

        originalPositionNoZ = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y            
        );

        foreach(var item in spriteRenderer) {
            item.color = new Color(
                item.color.r,
                item.color.g,
                item.color.b,
                0f                
            );
        }
    }
    void Update()
    {

        var playerVec = new Vector3(
            playerLocation.Value.x,
            playerLocation.Value.y
        );

        var yPos = playerVec.y - originalPositionNoZ.y;

        var distance = Mathf.Clamp(
            Vector3.Distance(
                new Vector3(
                    playerLocation.Value.x,
                    playerLocation.Value.y
                ),
                new Vector3(
                    originalPosition.x,
                    originalPosition.y
                )                        
            ),
            15,
            25
        );

        alpha = Mathf.Lerp(
            0f,
            yPos < 0 ? 1f : 1f,
            yPos < 0 ? 1f - ((distance - 15f) / 10f) : 1f
        );


        if(!Mathf.Approximately(
            alpha, lastAlpha
        )) {
            foreach (var item in spriteRenderer)
            {
                item.color = new Color(
                    item.color.r,
                    item.color.g,
                    item.color.b,
                    alpha
                );
            }

            lastAlpha = alpha;

        }

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            Mathf.Lerp(
                originalPosition.z,
                yPos < 0 ? -10f : 30f,
                yPos < 0 ? (distance - 15f) / 10f : 0
            )
        );
        
    }

}
