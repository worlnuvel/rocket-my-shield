using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject Square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    public Animator anim;
    float alive = 0f;
    bool isRunning = true;
    public static gameManager I;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    if(isRunning)
    {
        alive += Time.deltaTime;
        timeTxt.text = alive.ToString("N2");
        }
    }
    
    void makeSquare()
    {
        Instantiate(Square);
    }

    public void gameOver()
    {
        isRunning = false;
        anim.SetBool("isDie", true);
        Invoke("timeStop", 0.5f);
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2");
        if(PlayerPrefs.HasKey("bestscore") == false)
        {
            PlayerPrefs.SetFloat("bestscore", alive);
        }else
        {
            if (alive > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", alive);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");

    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    void timeStop()
    {
        Time.timeScale = 0f;
    }
}
