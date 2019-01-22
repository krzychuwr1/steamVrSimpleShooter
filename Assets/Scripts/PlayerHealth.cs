using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int StartingHealth;
    private int _currentHealth;

	// Use this for initialization
	void Start ()
    {
        _currentHealth = StartingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemyProjectile")
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                StartCoroutine(GameObject.FindObjectOfType<GameManagerScript>().EndGame(false));
            }
        }
        Destroy(col.gameObject);
    }
}
