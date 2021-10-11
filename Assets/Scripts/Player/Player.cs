using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _score; 
  
    private void ShowPointsInDebug()
    {
        Debug.Log("Cобрано очков:" + _score);
    }

    public void AddScore() 
    {
        _score++;
        ShowPointsInDebug();
    }
}