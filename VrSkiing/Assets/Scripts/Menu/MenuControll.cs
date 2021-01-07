using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuControll : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ButtonStart()
        {
            SceneManager.LoadScene(1);
        }
    }

}