using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Title;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI P2Score;
    public TextMeshProUGUI P1Score;
    public GameObject PlayerOne;
    public Player1Controller p1Script;
    public GameObject PlayerTwo;
    public Player2Controller p2Script;


    void Start()
    {
        Cursor.visible = false;
        p1Script = PlayerOne.GetComponent<Player1Controller>();
        p2Script = PlayerTwo.GetComponent<Player2Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // or if (Input.GetButtonUp("Cancel")) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStart();
        }
    }
    public void Restart()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    public void GameStart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Title.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        P1Score.gameObject.SetActive(true);
        P2Score.gameObject.SetActive(true);
        p1Script.canMove = true;
        p2Script.canMove = true;
        
    }
}
