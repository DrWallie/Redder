using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour//: CollisionManager
{
    public Vector2 zeroPoint = new Vector2(0, 0);

    [Space(10)]
    public Transform player;

    private Vector3 offset;

    private Quaternion facing;

    void Start()
    {
        offset = transform.position - player.position;

        facing = transform.rotation;
    }

    void LateUpdate()
    {
        Vector2 gravDir = ((Vector2)player.position - zeroPoint).normalized;

        Vector2 g = (Vector2)transform.position - zeroPoint;

        float θ = Mathf.Atan2(g.y, g.x) * Mathf.Rad2Deg;
        transform.transform.rotation = Quaternion.Euler(0, 0, θ+90);

        transform.position = player.position + offset;
    }
}