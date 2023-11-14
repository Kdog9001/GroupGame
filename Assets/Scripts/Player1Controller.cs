using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        p2Script = PlayerTwo.GetComponent<Player2Controller>();
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
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    void Block()
    {
        if(Input.GetKey("x")) 
        {
            Blocking = true;
            HSword.SetActive(false);
            LSword.SetActive(false);
            BSword.SetActive(true);
        }
    }

    void AttackHigh()
    {
        if (Input.GetKeyDown("z"))
        {
            Blocking = false;
            HSword.SetActive(true);
            LSword.SetActive(false);
            BSword.SetActive(false);
        }
    }

    void AttackLow()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Blocking = false;
            HSword.SetActive(false);
            LSword.SetActive(true);
            BSword.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("P2Sword"))
        {
            if (/*p2Script.*/Blocking == false)
            {
                Destroy(/*other.*/gameObject);
            }
        }
    }

}
