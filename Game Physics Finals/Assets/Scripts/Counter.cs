using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int shots = 8;
    public Text shotText;
    // Update is called once per frame
    void Update()
    {
        shotText.text = shots.ToString();
    }
    public void ShotsDeduction()
    {
        shots--;
        if (shots == 0)
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
