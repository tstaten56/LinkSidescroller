//using UnityEngine;
//using System.Collections;

//public class Spikes : MonoBehaviour {

//    private LinkControllerScript player;

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LinkControllerScript>();

//    }

//    void OnTriggerEnter2D(Collider2D col)
//    {
//        //When a collider enters the trigger
//        if (col.CompareTag("Player"))
//        {
//            //If player tag enters the spikes
//            player.Damage(1);

//            StartCoroutine(player.Knockback(0.02f, 1000, player.transform.position));
//        }
//    }
//}
using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{

    private LinkControllerScript player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LinkControllerScript>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            player.Damage(3);

            StartCoroutine(player.Knockback(0.02f, 600, player.transform.position));

        }

    }




}