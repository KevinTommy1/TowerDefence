using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum gameStatus
{
    next,
    play,
    gameover,
    win
}

public class GameManager : Singleton<GameManager>
{
    
    private int totalMoney = 10;
    private int whichEnemiesToSpawn = 0;

    public int TotalMoney
    {
        get => totalMoney;
        private set
        {
            totalMoney = value;
            totalMoneyLabel.text = totalMoney.ToString();
        }
    }
    

    public void AddMoney(int amount)
    {
        TotalMoney += amount;
    }

    public void SubtractMoney(int amount)
    {
        TotalMoney -= amount;
    }
    
}