using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform crosshair, ship;
    public float crossHairRadius = 2f;

    [Space(10)]
    public Vector2 zeroPoint = new Vector2(0, 0);

    [Space(10)]
    public float speed = 20f, rotationSpeed = 10f;
    public float gravity = 5f;

    [Space(10)]
    BoxCollider2D col;
    private Vector2 velocity;

    //public float chargeTime =1f;
    //private float currentChargeTime;
    //public float maxCharge = 10;

    private float vel;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()//Flight()
    {
        velocity = Vector2.zero;
        Vector2 gravDir = ((Vector2)ship.position - zeroPoint).normalized;

        #region Crosshair

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 center = ship.position;

        Vector2 direction = mousePosition - center; //direction from Center to Cursor
        Vector2 normalizedDirection = direction.normalized;

        crosshair.position = center + (normalizedDirection * crossHairRadius);

        ship.right = ((Vector2)crosshair.position - center).normalized;
        #endregion

        if (Input.GetButton("Fire1"))
        {
            velocity += ((Vector2)ship.right).normalized * speed;
        }
        else
        {

        }
    
        velocity += (gravDir * gravity); //gravity

        ship.position += (Vector3)velocity * Time.deltaTime;
        //Move(velocity * Time.deltaTime);
    }

    void Move(Vector2 velocity)
    {
        transform.Translate(velocity);
    }
}
