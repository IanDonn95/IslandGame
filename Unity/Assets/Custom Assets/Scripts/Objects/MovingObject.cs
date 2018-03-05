using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

    public float speed = .5f;
    public LayerMask blockingLayer;
    private float distance = 0;
    private float time = 0;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    // Use this for initialization
    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 change = new Vector2(xDir, yDir);
        //change = change / change.magnitude; //unit direction
        //change = change * inverseMoveTime * Time.deltaTime; //at entity speed
        Vector2 end = start + change;
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;
        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
    }

    protected virtual void AttemptMove<T>(int xDir, int yDir) where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
        {
            return;
        }
        T hitComponent = hit.transform.GetComponent<T>();
        if (!canMove && hitComponent != null)
        {
            OnCantMove(hitComponent);
        }
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, speed * Time.deltaTime);
        distance += speed * Time.deltaTime;
        time += Time.deltaTime;
        Debug.Log("t " + time + " d " + distance);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //while (sqrRemainingDistance > float.Epsilon)
        //{
       //     yield return null;
        //}
        yield return null;
    }

    protected abstract void OnCantMove<T>(T component) where T : Component;
}
