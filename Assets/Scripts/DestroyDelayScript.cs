using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelayScript : MonoBehaviour {

	void Awake () {
        Destroy(gameObject, 4);
    }
	
}
