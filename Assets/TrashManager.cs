using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;


public class TrashManager : MonoBehaviour
{
    //宣告分數參數

    public static int Trash;

    //宣告文字UI

    public Text ShowScore;

    private void Start()
    {
        Trash = 0;
        // 初始化分数
        if (ShowScore == null)
        {
            Debug.LogError("trashTextTMP is not assigned. Please assign a TextMeshProUGUI component in the Inspector.");
        }
        else
        {
            Update();
        }
    }
    void Update()

    {

        //讓UI文字與分數同步

        ShowScore.text = "Trash Count:"+Trash.ToString();

    }
}
