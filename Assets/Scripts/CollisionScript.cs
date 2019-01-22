using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public int EnemyHealth = 100;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        //Destroy(col.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "projectile") return;
        EnemyHealth--;
        Destroy(col.gameObject);
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
