using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("col.isTrigger");
        //Debug.Log(col.isTrigger);
        //Debug.Log("col.CompareTag(Enemy)");
        //Debug.Log(col.CompareTag("Enemy"));
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
