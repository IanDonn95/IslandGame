using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : BaseItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collision");
    }
    public override void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("trigger");
    }
}
