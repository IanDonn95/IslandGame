using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : BaseItem {

	// Use this for initialization
	public void Start () {
        this.itemName = "Test Pickup";
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
        Player p = coll.gameObject.GetComponent<Player>();
        Debug.Log("this- " + this);
        p.CollectItem(this);
        gameObject.active = false;
    }
}
