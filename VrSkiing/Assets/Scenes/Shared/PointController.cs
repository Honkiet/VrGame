using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Points
{
    public class PointController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI scoreText;
        private int score;

        public void AddScore(int x)
        {
            score += x;
            scoreText.text = "Points: " + score;
        }
    }

}
