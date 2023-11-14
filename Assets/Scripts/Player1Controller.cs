using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    public float stabtime = 1;
    public float stabSpeed = 15;
    private string attack;
    public bool HReady;
	public bool LReady;


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
        if (attack == "HS")
        {
            HSword.transform.Translate(Vector3.right * stabSpeed * Time.deltaTime);
        }
        else if(attack == "HSR")
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
            HReady = true;
        }
        if (HReady == true && Input.GetKeyDown("z"))
        {
			StartCoroutine("HighStab");
        }

    }
    IEnumerator HighStab()
    {
        attack = "HS";
        yield return new WaitForSeconds(stabtime);
        attack = "HSR";
        yield return new WaitForSeconds(stabtime);
        attack = "";
        //transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
	IEnumerator LowStab()
	{
		attack = "LS";
		yield return new WaitForSeconds(stabtime);
        attack = "LSR";

		yield return new WaitForSeconds(stabtime);
		attack = "";
		//transform.Translate(Vector3.right * speed * Time.deltaTime);

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
		if (LReady == true && Input.GetKeyDown(KeyCode.Space))
		{
			LowStab();
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
