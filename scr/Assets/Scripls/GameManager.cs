using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private bool isGameOver = false;
    public GameObject GameOverScreen;
    public GameObject ScoreObject;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            PlayerDie();
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int Getscore()
    {
        return score;
    }

    public void EnemySkillPlayer()
    {
        isGameOver = true;
    }

    public void PlayerDie()
    {
        GameOverScreen.SetActive(true);
        ScoreObject.SetActive(false);
    }

    public bool GameOver()
    {
        return isGameOver;
    }
}
