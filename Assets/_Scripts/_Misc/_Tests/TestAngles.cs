using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAngles : MonoBehaviour
{
    public Vector2 rayDirection = new Vector2(1, 1);
    public List<Transform> corners = new List<Transform>();

    [Space(10)]
    public float raySpacing = 0.25f;

    private Transform lastCorner;

    public void Update()
    {
        UpdateRayOrigins();
        UpdateRaySpacing();

        Debug.DrawRay(transform.position, rayDirection.normalized);
    }

    public void UpdateRayOrigins()
    {
        for(int i = 0; i < corners.Count; i++)
        {
            if (lastCorner != null)
            {
                Vector2 edge = (corners[i].position - lastCorner.position);
                float edgeMagnitude = edge.magnitude;
                float edgeRayCount = (edgeMagnitude / raySpacing);

                for (int j = 0; j < (edgeRayCount); j++)
                {
                    Vector2 rayPos = ((Vector2)corners[i].position + (edge.normalized * (edgeRayCount * j)));
                    Debug.DrawRay(rayPos, new Vector2(edge.y, -edge.x), Color.green);
                }
                //lastCorner = corners[corners.Count];
            }
            //print((corners[i].position - lastCorner.position).magnitude);

            lastCorner = corners[i];
        }
    }

    public void UpdateRaySpacing()
    {

    }
}
