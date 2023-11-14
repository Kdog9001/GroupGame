using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public GameObject HSword;
    public GameObject LSword;
    public GameObject BSword;
    public GameObject PlayerOne;
    public Player1Controller p1Script;
    public bool Blocking;


    void Start()
    {
        p1Script = PlayerOne.GetComponent<Player1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AttackHigh();
        AttackLow();
        Block();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    void Block()
    {
        if (Input.GetKey("8"))
        {
            Blocking = true;
            HSword.SetActive(false);
            LSword.SetActive(false);
            BSword.SetActive(true);
        }
    }

    void AttackHigh()
    {
        if (Input.GetKeyDown("7"))
        {
            Blocking = false;
            HSword.SetActive(true);
            LSword.SetActive(false);
            BSword.SetActive(false);
        }
    }

    void AttackLow()
    {
        if (Input.GetKeyDown("4"))
        {
            Blocking = false;
            HSword.SetActive(false);
            LSword.SetActive(true);
            BSword.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("P1Sword"))
        {
            if(p1Script.Blocking == false)
                
            {
                Destroy(other.gameObject);
            }
            
        }
    }
}