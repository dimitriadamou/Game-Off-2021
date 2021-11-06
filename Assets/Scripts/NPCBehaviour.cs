using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Route CurrentRoute;

    public SpriteRenderer spriteRenderer;

    Vector3 originalPosition;

    int routeIndex = 0;

    private bool canRoute = true;

    private float time = 0f;
    void Start()
    {
        originalPosition = transform.position;

        Vector3 currentPosition = transform.position;
        currentPosition.y = 0;
        int maxIndex = CurrentRoute.Routes.Count - 1;
        int nextRoute = routeIndex >= maxIndex ? 0 : routeIndex + 1;
        Vector3 startPosition = CurrentRoute.Routes[routeIndex];
        Vector3 endPosition = CurrentRoute.Routes[nextRoute];

        float p1Distance = Vector3.Distance(
            startPosition,
            endPosition
        );

        float p2Distance = Vector3.Distance(
            currentPosition,
            endPosition
        );

        time = 1 - (p2Distance / p1Distance);
    }

    public void setAlpha(float alpha)
    {
        this.spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            alpha
        );
    }
    public void setScale(float alpha)
    {
        this.transform.localScale = new Vector3(alpha, alpha, alpha);
    }

    public bool ProcessRoute(float deltaTime)
    {

        int maxIndex = CurrentRoute.Routes.Count - 1;
        int nextRoute = routeIndex >= maxIndex ? 0 : routeIndex + 1;
        Vector3 startPosition = CurrentRoute.Routes[routeIndex];
        Vector3 endPosition = CurrentRoute.Routes[nextRoute];


        if(time <= 1) {
            time += deltaTime * CurrentRoute.RouteRate[routeIndex];

            //start position.
            transform.position = new Vector3(
                Mathf.LerpUnclamped(
                    startPosition.x,
                    endPosition.x,
                    time
                ),
                transform.position.y,
                Mathf.LerpUnclamped(
                    startPosition.z,
                    endPosition.z,
                    time
                )
            );
        } else {
            time -= 1f;
            routeIndex++;
            if(routeIndex > maxIndex) {
                routeIndex = 0;
                return true;
            }
        }

        return false;
    }
}
