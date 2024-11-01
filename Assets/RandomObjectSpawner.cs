using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // 要生成的物件陣列
    public float spawnInterval = 3.0f;   // 生成間隔時間
    public RectTransform MainCanvasRectTransform;  // Canvas的RectTransform
    public Vector2 spawnAreaMin;         // 生成範圍最小值
    public Vector2 spawnAreaMax;         // 生成範圍最大值
    private bool gameEnded = false;      // 游戏结束标志

    void Start()
    {
        StartCoroutine(SpawnObjects());  // 開始協程
    }

    IEnumerator SpawnObjects()
    {
        while (!gameEnded)  // 無限迴圈
        {
            yield return new WaitForSeconds(spawnInterval);  // 等待指定的時間間隔

            // 隨機選擇一個物件
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // 生成物件
            GameObject instantiatedObject = Instantiate(objectToSpawn);

            // 確保生成物件作為Canvas的子物件
            instantiatedObject.transform.SetParent(MainCanvasRectTransform, false);

            // 設置隨機生成位置
            RectTransform rectTransform = instantiatedObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
                );
            }

            // 確保生成的物件比例正確
            instantiatedObject.transform.localScale = Vector3.one;
            // 检查物体数量是否超过20，如果超过则结束游戏
            if (GetTotalObjectsCount() >= 30 )
            {
                EndGame1();
            }
            else if(ScoreManager.Score >= 100)
            {
                EndGame2();
            }
        }
    }
    // 计算场上所有带有特定标签的物件数量
    public int GetTotalObjectsCount()
    {
        int totalCount = 0;
        foreach (var tag in new string[] { "bottle", "trash", "paper", "food" })
        {
            totalCount += GameObject.FindGameObjectsWithTag(tag).Length;
        }
        TrashManager.Trash  = totalCount-59;
        
        return totalCount-59;
    }



    void EndGame1()
    {
        gameEnded = true;  // 设置游戏结束标志为true，停止生成物体

        // 这里你可以实现结束游戏的逻辑，例如切换到游戏结束场景或显示游戏结束UI
        Debug.Log("遊戲結束!");

        // 示例：加载游戏结束场景
        SceneManager.LoadScene("END");
    }
    void EndGame2()
    {
        gameEnded = true;  // 设置游戏结束标志为true，停止生成物体

        // 这里你可以实现结束游戏的逻辑，例如切换到游戏结束场景或显示游戏结束UI
        Debug.Log("遊戲結束!");

        // 示例：加载游戏结束场景
        SceneManager.LoadScene("Sucess");
    }
}
