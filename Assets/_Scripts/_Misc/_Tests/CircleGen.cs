using UnityEngine;

public class CircleGen : MonoBehaviour
{
    public GameObject cube;
    public float interval = 0.00125f;
    public float radius = 120f;
    private float θ = 0f;

    void Start()
    {
        for (int i = 0; i < (int)((1f / interval) + 2f); i++)
        {
            θ += (2.0f * Mathf.PI * interval);

            float x = radius * Mathf.Cos(θ);
            float y = radius * Mathf.Sin(θ);

            Vector3 pos = new Vector3(x, y, 0);

            //var dir = (transform.position - pos).normalized;

            GameObject curCube = Instantiate(cube, pos, Quaternion.LookRotation(transform.position - pos));//Quaternion.FromToRotation(Vector3.forward, Vector3.up) * Quaternion.LookRotation(transform.position - pos));//Quaternion.LookRotation(transform.position - pos));
            curCube.transform.SetParent(transform);
        }
    }
}