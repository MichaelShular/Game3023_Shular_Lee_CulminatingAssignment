using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Vector2 input;
    public PlayerAbility player;
    public Ability a;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("EventSystem").GetComponent<GameState>().LoadPlayerPosition();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        settingAnimationClip();
        if(Input.GetKeyUp(KeyCode.O))
        {
            player.currentAbility[0] = a;
        }
    }

    private void move()
    {

        if (!isWalking)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                targetLocation = transform.position;
                targetLocation.x += input.x;
                targetLocation.y += input.y;
                if(input.x > 0)
                    direction = CardinalDirections.East;
                else if(input.x < 0)
                    direction = CardinalDirections.West;
                else if (input.y > 0)
                    direction = CardinalDirections.North;
                else if (input.y < 0)
                    direction = CardinalDirections.South;
                if (IsWalkable(targetLocation))
                    StartCoroutine(MoveCheck(targetLocation));
            }           
        }       
    }
    IEnumerator MoveCheck(Vector3 targetPosition)
    {
        isWalking = true;
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);            
            yield return null;
        }       
        transform.position = targetPosition;
        isWalking = false;
        CheckEncounters();
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.3f, collisionObject) != null)
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
            if (Random.Range(1,101) <= EncounterPercentage)
            {
                Debug.Log("Battle Start");
                //GameObject.Find("EventSystem").GetComponent<GameState>().SavePlayer();                
                SceneManager.LoadScene("BattleScene");                
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
