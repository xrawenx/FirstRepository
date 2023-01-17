using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPointToPoint : MonoBehaviour
{
    public bool chasePlayer;

    private Animator anim;

    private Vector3 tempScale;

    [SerializeField]
    private Transform[] movementPoints;

    private Vector2 currentMovementPoint;

    private int currentMovementPointIndex, previousMovementPointIndex;

    [SerializeField]
    private float moveSpeed = 2f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        SetMovementPointTarget();
    }

    private void Update()
    {
        MoveToTarget();
        HandleFacingDirection();
    }

    void AnimateMovement(bool walk)
    {
        anim.SetBool("Walk", walk);
    }

    void MoveToTarget()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, currentMovementPoint, Time.deltaTime * moveSpeed);

        if (Vector2.Distance(transform.position, currentMovementPoint) < 0.1f)
        {
            SetMovementPointTarget();
        }

        
    }

    void SetMovementPointTarget()
    {
        while (true)
        {

            currentMovementPointIndex = Random.Range(0, movementPoints.Length);

            if (currentMovementPointIndex != previousMovementPointIndex)
            {
                previousMovementPointIndex = currentMovementPointIndex;
                currentMovementPoint = movementPoints[currentMovementPointIndex].position;
                break;
            }
        }
    }

    void HandleFacingDirection()
    {
        tempScale = transform.localScale;

        if (transform.position.x > currentMovementPoint.x)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else if (transform.position.x < currentMovementPoint.x)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasePlayer = true;
            currentMovementPoint = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasePlayer = false;
            SetMovementPointTarget();
        }
    }

} // class
