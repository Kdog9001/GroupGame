using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public GameObject HSword;
    public GameObject LSword;
    public GameObject BSword;
    public bool Blocking;
    public GameObject PlayerTwo;
    public Player2Controller p2Script;
    public float stabtime = 1;
    public float stabSpeed = 15;
    private string attack = "";
    public bool HReady;
    public bool LReady;
    private GameManager gameManager;
    public bool canMove;
    public bool hasPowerup;
    public GameObject Powerup;
    public float knockback = 5;
    private int p1score;
    public TextMeshProUGUI P1Score;
    public TextMeshProUGUI P1win;
    void Start()
    {
        p2Script = PlayerTwo.GetComponent<Player2Controller>();
        gameManager = GameObject.Find("game manager").GetComponent<GameManager>();
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AttackHigh();
        AttackLow();
        Block();
        if (attack == "HS")
        {
            HSword.transform.Translate(Vector3.right * stabSpeed * Time.deltaTime);
        }
        else if (attack == "HSR")
        {
            HSword.transform.Translate(Vector3.left * stabSpeed * Time.deltaTime);
        }
        if (attack == "LS")
        {
            LSword.transform.Translate(Vector3.right * stabSpeed * Time.deltaTime);
        }
        else if (attack == "LSR")
        {
            LSword.transform.Translate(Vector3.left * stabSpeed * Time.deltaTime);
        }
        if (transform.position.x < -25)
        {
            //add +1 to score everytime other player when player is other player is at 2 or three wins then the game fully restarts
            //make it when a player has enough wins a message appears saying which player wins and the score is reset
            p1score = 0;
            UpdateScore(1);
            //if (p1score == 2)
            //{
                //P1win.gameObject.SetActive(true);
                //gameManager.Restart();
            //}
        }
    }

    void Move()
    {
        if (Input.GetKey("d") && canMove == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a") && canMove == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    void Block()
    {
        if (Input.GetKey("x"))
        {
            Blocking = true;
            canMove = false;
            HSword.SetActive(false);
            LSword.SetActive(false);
            BSword.SetActive(true);
        }

        if (Input.GetKeyUp("x"))
        {
            Blocking = false;
            canMove = true;
        }

    }

    void AttackHigh()
    {
        if (Input.GetKeyDown("z") && attack == "")
        {
            Blocking = false;

            HSword.SetActive(true);
            LSword.SetActive(false);
            BSword.SetActive(false);
            HReady = true;
            if (HReady == true)
            {
                StartCoroutine("HighStab");
            }
        }
    }
    
    
    void AttackLow()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attack == "")
        {
            Blocking = false;

            HSword.SetActive(false);
            LSword.SetActive(true);
            BSword.SetActive(false);
            LReady = true;

            if (LReady == true)
            {
                StartCoroutine("LowStab");
            }

        }

    }
    IEnumerator HighStab()
    {
        HReady = false;
        attack = "HS";
        yield return new WaitForSeconds(stabtime);
        attack = "HSR";
        yield return new WaitForSeconds(stabtime);
        attack = "";
        //transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    IEnumerator LowStab()
    {
        LReady = false;
        attack = "LS";
        yield return new WaitForSeconds(stabtime);
        attack = "LSR";

        yield return new WaitForSeconds(stabtime);
        attack = "";
        //transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    private Transform GetTransform()
    {
        return transform;
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
            IEnumerator PowerupCountdownRoutine()
            {
                yield return new WaitForSeconds(5);
                hasPowerup = false;
            }
            {
                if (other.CompareTag("P2Sword"))
                {
                    if (p2Script.Blocking == false)
                    {
                        transform.Translate(Vector3.left);
                    }
                     if (other.gameObject.CompareTag("P2Sword"))
                    {
                        hasPowerup = true;
                        transform.Translate(Vector3.left* 2 * knockback * Time.deltaTime);
                    }
                    return;                
                }
            }
            
        }
   
    }
    public void UpdateScore(int scoretoadd)
            {
                p1score += scoretoadd;
                P1Score.text = "Player One: " + p1score;
            }
}

