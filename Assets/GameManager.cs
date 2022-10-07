using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    string[,] crossOrCircle = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
    TextMeshProUGUI[] texts =new TextMeshProUGUI[9];

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
       // if (!turnX) return;
        y = x % 10;
        k = x / 10;
        if (crossOrCircle[k, y] != "") return;       
        crossOrCircle[k, y] = turnX ? "X" : "O";
        turnX = !turnX;
        CheckIfGameEnd();
      //  if (!turnX)
         //   AITurn();
    }

    private void AITurn()
    {
        //List<List<int>> possibleMoves = new List<List<int>>();
        //for (int i = 0; i < 3; i++)
        //{

        //    for (int j = 0; j < 3; j++)
        //    {
        //        if (crossOrCircle[i, j] == "")
        //            possibleMoves.Add(new List<int> { i, j });
        //    }
        //}
        if (crossOrCircle[1, 1] == "")
        {
            crossOrCircle[1, 1] = "O";
            return;

        }
        if (crossOrCircle[0, 0] == "")
        {
            crossOrCircle[0, 0] = "O";
            return;
        }
        if (crossOrCircle[1, 0] == "")
        {
            crossOrCircle[1, 1] = "O";
            return;
        }
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
            int sideWays = 0;
            int down = 0;
            for (int j = 0; j < 3; j++)
            {
                //Determine if the game has straight line
                if (crossOrCircle[i, 0] == crossOrCircle[i, j] && crossOrCircle[i, j] != "")
                    sideWays++;
                //Determine if the game has finished without win line
                if (crossOrCircle[i, j] != "")
                    allFinish++;
                if (sideWays == 3)
                {
                    GameOver(true);
                    return;
                }
                //Determine if the game has finished without win line
                if (crossOrCircle[0, i] == crossOrCircle[j, i] && crossOrCircle[j, i] != "")
                    down++;
                if (down == 3)
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
      
      

        if (crossOrCircle[0, 2] == crossOrCircle[1, 1] && crossOrCircle[0, 2] == crossOrCircle[2, 0] && crossOrCircle[0, 2] != "")

            GameOver(true);

        if (crossOrCircle[0, 0] == crossOrCircle[1, 1] && crossOrCircle[0, 0] == crossOrCircle[2, 2] && crossOrCircle[0, 0] != "")

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
