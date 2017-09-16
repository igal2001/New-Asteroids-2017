using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour {

    [SerializeField]
    float TimeToDestroy;

	//kys
	void Start () {
        Destroy(gameObject, TimeToDestroy);
	}

}
