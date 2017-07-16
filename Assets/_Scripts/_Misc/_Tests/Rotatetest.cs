using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatetest : MonoBehaviour
{
    public Transform crosshair, ship;
    public float rotationSpeed = 10f, radius = 1f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        #region Crosshair

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 center = ship.position;

        Vector2 direction = mousePosition - center; //direction from Center to Cursor
        Vector2 normalizedDirection = direction.normalized;

        crosshair.position = center + (normalizedDirection * radius);

        #endregion

        ship.up = ((Vector2)crosshair.position - center).normalized;
    }

    //Je kunt halve cirkels maken door //direction.y = Mathf.Min(0f, direction.y);  or //if(diff.y > 0f){diff.y = 0f;} te doen

    //crosshair.position = center + Vector2.ClampMagnitude(direction, radius);
}