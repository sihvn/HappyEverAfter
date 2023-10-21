// Assuming you're using C# Scripting

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    private InputAction moveAction;
    private float _moveSpeed = 10f;
    private Vector3 moveVec = Vector3.zero;
    private Rigidbody2D playerBody;
    public GameConstants gameConstants;
    public Animator playerAnimator;
    public PlayerInput playerInput;
    private SpriteRenderer playerSprite;
    public AudioSource playerAttack;
    public GameObject player;
    AudioClip attack;
    AudioClip death;
    public AudioSource playerDeath;

    float upSpeed;
    GameObject slime;
    bool isFighting;
    [SerializeField] private TextAsset inkJSON;
    bool hasInteracted = false;

    private void Start()
    {
        attack = playerAttack.clip;
        death = playerDeath.clip;
        upSpeed = gameConstants.upSpeed;
        Application.targetFrameRate = 30;
        GameManager.Instance.gameRestart.AddListener(GameRestart);
        playerBody = GetComponent<Rigidbody2D>();
        //playerSprite = GetComponent<SpriteRenderer>(); 
    }
    private void Awake()
    {

    }
    private void Update()
    {
        playerBody.velocity = moveVec * _moveSpeed;
        playerAnimator.SetFloat("xSpeed", Mathf.Abs(playerBody.velocity.x));
        playerAnimator.SetFloat("ySpeed", Mathf.Abs(playerBody.velocity.y));
        if (playerInput.actions["attack"].IsPressed())
        {
            //playerAnimator.SetTrigger("PlayerFight");
            playerAnimator.SetBool("Fighting", true);
        }
        else
        {
            playerAnimator.SetBool("Fighting", false);
        }
        isFighting = playerAnimator.GetBool("Fighting");
        if (playerInput.actions["interaction"].IsPressed())

        {
            hasInteracted = true;
        }


    }
    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector2(inputVec.x, inputVec.y);
        if (inputVec.x > 0)
        {
            playerAnimator.SetTrigger("WalkRight");

        }
        else if (inputVec.x < 0)
        {
            playerAnimator.SetTrigger("WalkLeft");
        }
        else if (inputVec.y > 0)
        {
            playerAnimator.SetTrigger("WalkUp");
        }
        else if (inputVec.y < 0)
        {
            playerAnimator.SetTrigger("WalkDown");
        }

    }

    public void OnAttack()
    {
        playerAnimator.SetTrigger("PlayerFight");
        playerAnimator.SetBool("Fighting", true);
        playerAttack.PlayOneShot(attack);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Slime"))
        {
            slime = other.gameObject;
            //Debug.Log("Collided with slime");
            if (!isFighting)
            {
                playerDeath.PlayOneShot(death);
                playerAnimator.Play("player_die");
            }
            else
            {
                gameConstants.attackCount += 1;
            }

        }
        if (other.gameObject.CompareTag("NPC") && hasInteracted)
        {
            //Debug.Log("nuuuu223232u");
            gameConstants.dialogueMode = true;

        }

    }
    // public void OnInteraction()
    // {
    //     hasInteracted = true;
    // }
    void GameOverScene()
    {
        GameManager.Instance.GameOver();
    }
    public void GameRestart()
    {
        // reset position
        playerBody.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // reset animation
        playerAnimator.SetTrigger("gameRestart");


        // reset camera position
        //gameCamera.position = new Vector3(0, 0, -10);

    }
}

