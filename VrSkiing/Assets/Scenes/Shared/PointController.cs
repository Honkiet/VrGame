using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Points
{
    public class PointController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI scoreText;
        public float score;
        public float scorePerSecond;

        public void AddScore()
        {
            score += scorePerSecond * Time.deltaTime;
            UpdateScoretext(); // might move into another script, but for now here is fine
        }

        private void UpdateScoretext() 
        {
            scoreText.text = "" + (int)score;
        }
    }

}
