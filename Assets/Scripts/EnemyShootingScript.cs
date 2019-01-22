using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour {

    public Rigidbody projectilePrefab;

    // Use this for initialization
    void Start () {
        StartCoroutine(Shooting());

    }

    // Update is called once per frame
    void Update ()
    {
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Random.value < 0.15f)
            {
                var newProjectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
                
                var direction = GameObject.FindWithTag("headCollider").transform.position - transform.position;
                newProjectile.transform.LookAt(direction);
                newProjectile.velocity = direction * 0.8f;
                Destroy(newProjectile, 5);
            }
        }
    }
}
