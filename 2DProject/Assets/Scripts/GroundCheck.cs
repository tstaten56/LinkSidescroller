using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private LinkControllerScript player;
    private int collisionCount = 0;
    void Start()
    {
        player = gameObject.GetComponentInParent<LinkControllerScript>();
    }

    void FixedUpdate()
    {
        //Debug.Log(collisionCount);
        if (collisionCount != 0)
        {
            player.grounded = true;
            //Debug.Log(player.grounded);
        }
        else
        {
            collisionCount = 0;
            player.grounded = false;
            //Debug.Log(player.grounded);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        collisionCount++;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        collisionCount--;
    }
}
