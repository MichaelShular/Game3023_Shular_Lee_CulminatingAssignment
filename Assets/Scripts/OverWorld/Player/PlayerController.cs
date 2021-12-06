using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 targetLocation;
    [SerializeField] private float speed;
    [SerializeField] private CardinalDirections direction = CardinalDirections.South;
    private bool isWalking;
    [SerializeField] private int EncounterPercentage;
    private Animator animator;
    public LayerMask grass;
    public LayerMask collisionObject;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        settingAnimationClip();
    }

    private void move()
    {

        if (!isWalking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                targetLocation = transform.position + Vector3.right * Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = CardinalDirections.East;
                }
                else
                {
                    direction = CardinalDirections.West;
                }                                
            }
            else if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
            {
                targetLocation = transform.position + Vector3.up * Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    direction = CardinalDirections.North;
                }
                else
                {
                    direction = CardinalDirections.South;
                }                                
            }
            if(IsWalkable(targetLocation))
                StartCoroutine(MoveCheck(targetLocation));
        }        
        
    }
    IEnumerator MoveCheck(Vector3 targetPosition)
    {
        isWalking = true;
        while((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
            yield return null;
        }
        transform.position = targetPosition;
        isWalking = false;
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, collisionObject) != null)
        {
            return false;
        }

        return true;
    }
    private void settingAnimationClip()
    {
        animator.SetBool("IsMoving", isWalking);
        animator.SetInteger("Direction", (int)direction);
        
    }
    private void CheckEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grass))
        {
            if (Random.RandomRange(0,100) <= EncounterPercentage)
            {
                Debug.Log("Battle Start");
                //TODO: start battle scene
            }
        }
    }


}
public enum CardinalDirections
{
    North,
    East,
    South,
    West
}
