using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ColliderTest : MonoBehaviour
{
    public struct RayOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public RayOrigins rayOrigins;

    public Vector2 rayDirection;

    public BoxCollider2D col2D;
    public float skinWidth = 0.15f;
    public float raySpacing = 0.25f;

    private int horRayCount;
    private int verRayCount;

    private float horRaySpacing;
    private float verRaySpacing;

    void Start()
    {
        if(col2D == null)
        {
            transform.GetComponentInChildren<BoxCollider2D>();
        }
    }

    void Update ()
    {
        UpdateRayOrigins();
        UpdateRaySpacing();

        //print(rayOrigins.topLeft.magnitude)
        print((rayOrigins.bottomLeft - rayOrigins.topLeft).magnitude );
    }

    public void Move(Vector2 velocity)
    {
        //UpdateRayOrigins();
        //UpdateRaySpacing();

        transform.Translate(velocity);
    }

    public void UpdateRayOrigins()
    {
        Bounds bounds = col2D.bounds;
        bounds.Expand(skinWidth * -2); //creates a small inward range to the rays so there always be space to shoot them from.

        rayOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        rayOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        rayOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        rayOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void UpdateRaySpacing()
    {
        Bounds bounds = col2D.bounds;
        bounds.Expand(skinWidth * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        horRayCount = Mathf.RoundToInt(boundsHeight / raySpacing);
        verRayCount = Mathf.RoundToInt(boundsWidth / raySpacing);

        horRaySpacing = bounds.size.y / (horRayCount - 1);
        verRaySpacing = bounds.size.x / (verRayCount - 1);
    }
}