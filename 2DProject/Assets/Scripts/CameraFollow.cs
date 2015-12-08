using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject link; //Player

    public bool bounds; //do you want cam boundaries?

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start()
    {

        link = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, link.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, link.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            //Debug.Log(Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
