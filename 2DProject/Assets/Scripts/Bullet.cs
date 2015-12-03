using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true)
        {
            if(col.CompareTag("Player"))
            {
                col.GetComponent<LinkControllerScript>().Damage(1);
                //Must delete the bullet
                Destroy(gameObject);
            }

            //Causing annoying bugs here so I'll just delete it when it hits the player
            //Must delete the bullet
            //Destroy(gameObject);
        }
    }
}
