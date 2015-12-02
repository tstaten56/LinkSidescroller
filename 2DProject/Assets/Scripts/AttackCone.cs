using UnityEngine;
using System.Collections;

public class AttackCone : MonoBehaviour {

    public TurretAI turretAI;

    //Check if it is left attack range or the right
    public bool isLeft = false;

	void Awake()
    {
        turretAI = gameObject.GetComponentInParent<TurretAI>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turretAI.Attack(false); //false this is attacking left
            }
            else
            {
                turretAI.Attack(true); //Attacking right
            }
        }
    }
}
