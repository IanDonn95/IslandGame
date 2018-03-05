using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MovingObject {
    protected override void OnCantMove<T>(T component)
    {

    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public void Update () {
        int horizontal, vertical;
        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0 || vertical != 0)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttemptMove<BaseWall>(horizontal, vertical);
        }
    }
}
