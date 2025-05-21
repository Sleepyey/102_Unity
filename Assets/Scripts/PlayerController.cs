using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public float playerHp = 4f;
    public bool right;

    public float timer = 0f;

    public GameObject attackPrefabsR;
    public GameObject attackPrefabsL;
    public GameObject attackPrefabsRR;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public TextMeshProUGUI hpUI;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI rUI;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    private bool isGiant = false;
    private bool isInv = false;
    private bool isJum = false;
    private bool isSpd = false;
    private int countR = 0;

    private int dummy_b = 0;

    float score;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
        score = 1000f;
    }

    void Mhp()
    {
        playerHp--;

        Debug.Log(playerHp);
        if (playerHp == 4)
        {
            hpUI.text = "HP: ¢¾¢¾¢¾¢¾";
        }
        else if (playerHp == 3)
        {
            hpUI.text = "HP: ¢¾¢¾¢¾";
        }
        else if (playerHp == 2)
        {
            hpUI.text = "HP: ¢¾¢¾";
        }
        else if (playerHp == 1)
        {
            hpUI.text = "HP: ¢¾";
        }
    }

    //Start
    private void Start()
    {

    }

    // Update
    private void Update()
    {
        rUI.text = $"R / {countR}";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R) && countR > 0)
        {
            AttackRR();
        }

        if (playerHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.F) && right == true)
        {
            AttackR();
        }
        else if (Input.GetKeyDown(KeyCode.F) && right == false)
        {
            AttackL();
        }

        if (isInv == true)
        {
            timer -= Time.deltaTime;
            timerUI.text = "Invincibility: " + timer.ToString("0.00");
            if (timer <= 0)
            {
                isInv = false;
                timer = 0;
            }
        }

        if (isSpd == true)
        {
            float moveInputS = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInputS * 10, rb.velocity.y);
            if (moveInputS < 0)
            {
                transform.localScale = new Vector3(-1, 1f, 1f);
                right = false;
                pAni.SetTrigger("WalkAction");
            }
            if (moveInputS > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                right = true;
                pAni.SetTrigger("WalkAction");
            }
        }
        else
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            if (isGiant)
            {
                if (moveInput < 0)
                {
                    transform.localScale = new Vector3(-2f, 2f, 1f);
                    pAni.SetTrigger("WalkAction");
                    right = false;
                }
                if (moveInput > 0)
                {
                    transform.localScale = new Vector3(2f, 2f, 1f);
                    right = true;
                    pAni.SetTrigger("WalkAction");
                }
            }
            else
            {
                if (moveInput < 0)
                {
                    transform.localScale = new Vector3(-1, 1f, 1f);
                    right = false;
                    pAni.SetTrigger("WalkAction");
                }
                if (moveInput > 0)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    right = true;
                    pAni.SetTrigger("WalkAction");
                }
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if (isJum == true)
            {
                rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                pAni.SetTrigger("JumpAction");
            }
            else
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                pAni.SetTrigger("JumpAction");
            }
        }
        score -= Time.deltaTime;
    }

    void AttackRR()
    {
        Transform playerTransform = transform;

        Instantiate(attackPrefabsRR, playerTransform.position, playerTransform.rotation);

        countR--;
    }

    void AttackR()
    {
        Transform playerTransform = transform;

        Instantiate(attackPrefabsR, playerTransform.position, playerTransform.rotation);
    }

    void AttackL()
    {
        Transform playerTransform = transform;

        Instantiate(attackPrefabsL, playerTransform.position, playerTransform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.CompareTag("Finish"))
        {
            //HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            StageResultSaver.SaveStage(SceneManager.GetActiveScene().buildIndex, (int)score);

            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
        if (collision.CompareTag("Enemy"))
        {
            if (isGiant == true)
            {
                dummy_b++;
                Destroy(collision.gameObject);
            }
            else if (isInv == true)
            {
                dummy_b++;
            }
            else
            {
                Mhp();
            }
        }
        if (collision.CompareTag("EnemyB"))
        {
            if (isGiant == true)
            {
                dummy_b++;
                Destroy(collision.gameObject);
            }
            else if (isInv == true)
            {
                dummy_b++;
            }
            else
            {
                playerHp = 0;
            }
        }
        if (collision.CompareTag("Item"))
        {
            isGiant = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item_Inv"))
        {
            isInv = true;
            timer = 4;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item_Jum"))
        {
            isJum = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item_Spd"))
        {
            isSpd = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item_R"))
        {
            countR++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Boss_A"))
        {
            Mhp();
            Destroy(collision.gameObject);
        }
    }
}
