using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Space(10)]
    public Vector2 zeroPoint = new Vector2(0, 0);
    public float gravity = 10f;
    public float thrustForce;

    [Space(10)]
    public PlayerControl controller;
    private Vector2 velocity;

    [Space(10)]
    public Camera cam;

	void Update ()
    {
        Vector2 gravDir = ((Vector2)transform.position - zeroPoint).normalized; //Vector2 gravDir = -Vector2.up;
        #region Deprecated
        /*Vector2 mouse = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position); //Gets Screen co-ordinates of our plane
        Vector2 offset = (mouse - screenPoint); //new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //Debug.DrawRay(transform.position, transform.up, Color.blue);

        //Debug.DrawRay(transform.position, gravDir, Color.red);
        */
        #endregion

        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition); //Gets Screen position of the mouse
        Vector2 playerOnScreen = Camera.main.WorldToViewportPoint(transform.position); //Gets Screen position of the player

        float angle = Mathf.Atan2(playerOnScreen.y - mouseOnScreen.y, playerOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg; //Gets Angle between mouse and player
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90)); //Sets Rotation of player according to our angle

        Debug.DrawRay(transform.position, transform.up, Color.blue);

        if (Input.GetButtonDown("Fire1"))
        {
            //rigid.AddForce(-transform.up * thrustForce);
        }
       velocity += (gravDir * gravity)* Time.smoothDeltaTime;
       controller.Move(velocity * Time.deltaTime);

    }

    void LateUpdate()
    {
        #region Deprecated
        /*
        //Vector3 gravityRelative = transform.position - new Vector3(zeroPoint.x, zeroPoint.y, 0f);
        Vector2 gravityRelative = (Vector2)transform.position - zeroPoint;
        Quaternion camRot = Quaternion.LookRotation(gravityRelative);
        cam.transform.rotation = camRot; //Quaternion.Euler(0, 0, camRot);
        */
        #endregion
        cam.transform.position = transform.position;

        Vector2 g = (Vector2)transform.position - zeroPoint;

        float θ = Mathf.Atan2(g.y, g.x) * Mathf.Rad2Deg;
        //cam.transform.rotation = Quaternion.Euler(0, 0, θ+90);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 1f);
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.25f);
    }
}
