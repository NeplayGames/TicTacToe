using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    string[,] crossOrCircle = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

    private bool turnX = true;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] TextMeshProUGUI gameWonInfo;
    [SerializeField] GameObject gameWonObject;

    private void Start()
    {
        turnText.text = "CURRENT TURN " + (turnX ? "X" : "O");
    }
    int y; int k;
    public void setValue(int x)
    {
        y = x % 10;
        k = x / 10;
        if (crossOrCircle[k, y] != "") return;       
        crossOrCircle[k, y] = turnX ? "X" : "O";
        turnX = !turnX;
        CheckIfGameEnd();
    }
    public void setValue(TextMeshProUGUI x)
    {
       
        x.text = !turnX ? "X" : "O";
        
        turnText.text = "CURRENT TURN " + (turnX ? "X" : "O");
       

    }
    private void CheckIfGameEnd()
    {
        int allFinish = 0;
        for (int i = 0; i < 3; i++)
        {
            int count = 0;
            for (int j = 0; j < 3; j++)
            {
                if (crossOrCircle[i, 0] == crossOrCircle[i, j] && crossOrCircle[i, j] != "")
                    count++;
                if (crossOrCircle[i, j] != "")
                    allFinish++;
                if (count == 3)
                {
                    GameOver(true);
                    return;
                }

            }
        }
        if(allFinish == 9)
        {
            GameOver(false);
        }
        for (int i = 0; i < 3; i++)
        {
            int count = 0;
            for (int j = 0; j < 3; j++)
            {
                if (crossOrCircle[0, i] == crossOrCircle[j, i] && crossOrCircle[j, i] != "")
                    count++;
                if (count == 3)
                {
                    GameOver(true);
                    return;
                }

            }
        }
        {
            int count = 0;
            for (int j = 1; j < 3; j++)
            {
                if (crossOrCircle[0, 0] == crossOrCircle[j, j] && crossOrCircle[j, j] != "")
                    count++;
                if (count == 2)
                {
                    GameOver(true);
                    return;
                }
            }
        }

        if (crossOrCircle[0, 2] == crossOrCircle[1, 1] && crossOrCircle[0, 2] == crossOrCircle[2, 0] && crossOrCircle[0, 2] != "")

            GameOver(true);




    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void GameOver(bool winner)
    {
        gameWonObject.SetActive(true);
        gameWonInfo.text = "The game completes with " +(winner?( !turnX ? "X" : "O"):"no one")+" winning the game.";
        Time.timeScale = 0;
    }
}
