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
    void Start()
    {
        
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
            HSword.SetActive(false);
            LSword.SetActive(false);
            BSword.SetActive(true);
        }
    }

    void AttackHigh()
    {
        if (Input.GetKeyDown("z"))
        {
            HSword.SetActive(true);
            LSword.SetActive(false);
            BSword.SetActive(false);
        }
    }

    void AttackLow()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HSword.SetActive(false);
            LSword.SetActive(true);
            BSword.SetActive(false);
        }
    }
}
