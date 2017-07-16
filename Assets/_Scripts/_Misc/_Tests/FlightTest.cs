using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightTest : MonoBehaviour
{
    public Vector2 zeroPoint = new Vector2(0, 0);

    [Space(10)]
    public float speed = 30f;
    public float gravity = 5f;

    [Space(10)]
    private Vector2 velocity;

	void Update ()
    {
        velocity = Vector2.zero;

        Vector2 gravDir = ((Vector2)transform.position - zeroPoint).normalized;

        #region Ship Rotation
        /*
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition); //Gets Screen position of the mouse
        Vector2 playerOnScreen = Camera.main.WorldToViewportPoint(transform.position); //Gets Screen position of the player

        float angle = Mathf.Atan2(playerOnScreen.y - mouseOnScreen.y, playerOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg; //Gets Angle between mouse and player
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90)); //Sets Rotation of player according to our angle
        */
        #endregion
        Debug.DrawRay(transform.position, transform.up, Color.blue);

        if (Input.GetButton("Fire1"))
        {
            print("bol");
            velocity += (Vector2)transform.up * speed;
        }
        velocity += (gravDir * gravity);

        Move(velocity * Time.deltaTime);
    }

    void Move(Vector2 velocity)
    {
        transform.Translate(velocity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 1f);
        //Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.25f);

        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mousePos.x = Mathf.Clamp(mousePos.x, 1f, int.MaxValue);
        mousePos.y = Mathf.Clamp(mousePos.y, -1f, int.MaxValue);

        Gizmos.DrawSphere(mousePos, 0.5f);
    }
}
