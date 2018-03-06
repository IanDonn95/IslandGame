using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    protected BoxCollider2D boxCollider;
    protected Rigidbody2D rb2D;
	// Use this for initialization
	protected virtual void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
