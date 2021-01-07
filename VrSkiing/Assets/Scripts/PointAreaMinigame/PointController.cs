using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
   
    public int damage;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public float timeRemaining = 10;
    private bool clicked = false;

    public void AddScore(int x)
    {
        damage = damage + x;
        score.text = "Damage : $" + damage.ToString();
    }
}
