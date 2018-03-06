using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : BaseObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("base");
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("baseT");
    }
}