using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D marioBody;

    private bool onGroundState = true;

    // global variables
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;

    // public GameObject enemies;

    // public GameObject inGameScene;
    // public GameObject gameOverScene;
    public Animator playerAnimator;
    public AudioSource playerAudio;
    // public AudioSource marioDeath;
    // public AudioSource enemyDeath;
    public Transform gameCamera;

    GameObject Goomba;


    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);
    public PlayerActions playerActions;
    //public GameManager gameManager;
    // public Sprite GoombaFlat;

    Vector3 prevPosition;
    Vector3 velocity;
    public GameConstants gameConstants;
    float deathImpulse;
    float upSpeed;
    float maxSpeed;
    float speed;
    private InputAction move;
    private Vector3 moveVec = Vector3.zero;


    // state
    [System.NonSerialized]
    public bool alive = true;
    private bool moving = false;
    private bool jumpedState = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = gameConstants.speed;
        maxSpeed = gameConstants.maxSpeed;
        deathImpulse = gameConstants.deathImpulse;
        upSpeed = gameConstants.upSpeed;

        playerActions = new PlayerActions();
        playerActions.gameplay.Enable();
        //moveDirection = playerActions.ReadValue<Vector2>();
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();

        //marioAnimator.SetBool("onGround", onGroundState);
        prevPosition = transform.position;
        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SetStartingPosition;

    }
    void Awake()
    {
        // GameManager.Instance.gameRestart.AddListener(GameRestart);
        playerActions = new PlayerActions();


    }
    // private void OnEnable() {
    //     move = playerActions.gameplay.move;
    //     move.Enable();
    // }
    // private void OnDisable() {
    //     move.Disable();
    // }
    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }
    public void SetStartingPosition(Scene current, Scene next)
    {
        // if (next.name == "World 1-2")
        // {
        //     // change the position accordingly in your World-1-2 case
        //     this.transform.position = new Vector3(-6.731f, -2.411f, 0.0f);
        // }
    }

    void GameOverScene()
    {
        // stop time
        Time.timeScale = 0.0f;
        //GameManager.Instance.GameOver();

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Goomba = other.gameObject;
            //     //Debug.Log("Collided with goomba!");

            //     // play death animation
            //     // marioAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            //     Vector3 contactPoint = other.
            if (velocity.y < 0)
            {
                //enemyDeath.PlayOneShot(enemyDeath.clip);
                //other.gameObject.GetComponent<SpriteRenderer>().sprite = GoombaFlat;
                //GameManager.Instance.IncreaseScore(1);
                // other.gameObject.SetActive(false);
                Invoke("ActivateObject", 0.2f);
            }
            else
            {
                //playerAnimator.Play("Mario_die");
                //marioDeath.PlayOneShot(marioDeath.clip);
                alive = false;
            }

        }

    }
    void ActivateObject()
    {
        Goomba.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //playerAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
        Vector3 currentPosition = transform.position;
        velocity = (currentPosition - prevPosition) / Time.deltaTime;
        prevPosition = currentPosition;
    }
    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;

        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
        }
    }
    public void Jump()
    {
        if (alive && onGroundState)
        {
            // jump
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
        }
    }
    public void JumpHold()
    {
        if (alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if ((col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Enemies") || col.gameObject.CompareTag("Obstacles")) && !onGroundState)
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            //playerAnimator.SetBool("onGround", onGroundState);
        }
    }


    // FixedUpdate may be called once per frame. See documentation for details.
    void FixedUpdate()
    {
        if (alive && moving)
        {
            //Move(faceRightState == true ? 1 : -1);
        }

    }
    void Move(InputValue input)
    {

        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector3(inputVec.x, inputVec.y, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(moveVec * speed);
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            //FlipMarioSprite(value);
            moving = true;
            //Move(value);
        }
    }
    // public void RestartButtonCallback(int input)
    // {
    //     Debug.Log("Restart!");
    //     // reset everything
    //     GameRestart();
    //     // resume time
    //     Time.timeScale = 1.0f;
    // }

    // public void GameRestart()
    // {
    //     // reset position
    //     marioBody.transform.position = new Vector3(-4.0f, -3.43f, 0.0f);
    //     // reset sprite direction
    //     faceRightState = true;
    //     marioSprite.flipX = false;

    //     // reset animation
    //     marioAnimator.SetTrigger("gameRestart");
    //     alive = true;

    //     // reset camera position
    //     gameCamera.position = new Vector3(0, 0, -10);

    // }

    void PlayJumpSound()
    {
        // play jump sound
        playerAudio.PlayOneShot(playerAudio.clip);
    }
}