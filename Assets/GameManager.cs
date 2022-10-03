using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    string[,] crossOrCircle = new string[3,3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

    private bool CheckIfGameEnd()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {

            }
        }
        return false;
    }
}
