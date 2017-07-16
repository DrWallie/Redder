using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionManager : MonoBehaviour
{
    public LayerMask collisionMask;
    [Space(10)]
    public float skinWidth = 0.15f; //public const float skinWidth = .015f;
    public float raySpacing = 0.24f; //public const float dstBetweenRays = .25f;
    [Space(10)]
    public int horRayCount;
    public int verRayCount;

    [HideInInspector]
    public float horRaySpacing;
    [HideInInspector]
    public float verRaySpacing;

    [HideInInspector]
    public BoxCollider2D col;
    public RayOrigins rayOrigins;

    public virtual void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    /*public virtual void Start()
    {
        //CalculateRaySpacing();
    }*/

    public void UpdateRayOrigins()
    {
        Bounds bounds = col.bounds;
        bounds.Expand(skinWidth * -2);

        rayOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        rayOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        rayOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        rayOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CheckBoundAngle(Vector2 direction)
    {

    }

    public void UpdateRaySpacing()
    {
        Bounds bounds = col.bounds;
        bounds.Expand(skinWidth * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        horRayCount = Mathf.RoundToInt(boundsHeight / raySpacing);
        verRayCount = Mathf.RoundToInt(boundsWidth / raySpacing);

        horRaySpacing = bounds.size.y / (horRayCount - 1);
        verRaySpacing = bounds.size.x / (verRayCount - 1);
    }

    public struct RayOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
