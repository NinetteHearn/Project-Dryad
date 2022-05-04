using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int flowerCount = 8;

    public bool gameWin;
    public bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flowerCount == 0)
        {
            gameActive = false;
            gameWin = true;
            GameOver();
        }
    }

    //counting flowers collected
    public void CollectFlower()
    {
        flowerCount--;
        Debug.Log($"Flower Collected, flowers remaining {flowerCount}");

        
            
    }

    public void GameOver()
    {
        if (gameWin)
        {
            Debug.Log($"You Win the Game!");
        }
        else if (!gameWin)
        {
            Debug.Log($"You Lose the Game!");
        }
    }
}
