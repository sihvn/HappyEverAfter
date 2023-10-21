using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    AudioClip audioClip;
    public AudioSource enemyDeath;


    public Vector3 startPosition;
    public Animator enemyAnimator;
    public GameConstants gameConstants;
    public GameObject slime;

    public Animator playerAnimator;
    private Rigidbody2D enemyBody;
    public SpriteRenderer enemySprite;
    public bool changeColour = false;


    [System.NonSerialized]
    bool alive = true;
    bool isFighting;

    void Awake()
    {

    }

    void Start()
    {
        audioClip = enemyDeath.clip;
        GameManager.Instance.gameRestart.AddListener(GameRestart);
        enemyBody = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity()
    {
        velocity = new Vector2(moveRight * maxOffset / enemyPatroltime, 0);
    }
    void MoveSlime()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }
    void DisableSlime()
    {
        slime.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            if (isFighting)
            {
                enemyDeath.PlayOneShot(audioClip);
                enemyAnimator.SetTrigger("slimeDie");
            }
            else
            {
                Debug.Log("move back");
            }
        }

    }
    // void OnCollisionEnter2D(Collision2D col){

    // }
    public void GameRestart()
    {
        slime.SetActive(true);
        transform.localPosition = startPosition;
        originalX = startPosition.x;
        moveRight = -1;
        ComputeVelocity();
    }

    void Update()

    {
        isFighting = playerAnimator.GetBool("Fighting");
        if (enemyBody != null)
        {
            if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
            {// move goomba
                enemySprite.flipX = false;
                MoveSlime();
            }
            else
            {
                enemySprite.flipX = true;
                // change direction
                moveRight *= -1;
                ComputeVelocity();
                MoveSlime();
            }
        }
        if (changeColour)
        {
            enemyAnimator.SetTrigger("colourChange");
        }

    }
}