using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //宣告分數參數

    public static int Score;

    //宣告文字UI

    public Text ShowScore;

    private void Start()
    {
        Score = 0;
        // 初始化分数
        if (ShowScore == null)
        {
            Debug.LogError("scoreTextTMP is not assigned. Please assign a TextMeshProUGUI component in the Inspector.");
        }
        else
        {
            Update();
        }
    }
    void Update()

    {

        //讓UI文字與分數同步

        ShowScore.text =  Score.ToString();

    }
    //public void UpdateScoreText()
    //{
    //    Debug.Log("Updating score text: " + Score.ToString());
    //    if (ShowScore != null)
    //    {
    //        ShowScore.text = "Score: " + Score.ToString();
    //    }
    //    else
    //    {
    //        Debug.LogError("scoreTextTMP is null. Make sure it is assigned in the Inspector.");
    //    }
    //}
}
