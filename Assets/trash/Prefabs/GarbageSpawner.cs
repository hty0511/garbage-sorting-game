using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject bottlePrefab;
    public Vector3 spawnAreaMin = new Vector3(-5, 0, 0);
    public Vector3 spawnAreaMax = new Vector3(5, 0, 0);

    void Start()
    {
        InvokeRepeating("SpawnBottles", 1f, 1f);
    }

    void SpawnBottles()
    {
        int numberOfBottles = Random.Range(1, 4);

        for (int i = 0; i < numberOfBottles; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            GameObject newBottle = Instantiate(bottlePrefab, spawnPosition, Quaternion.identity);

            // 确保新生成的对象具有正确的比例
            newBottle.transform.localScale = Vector3.one;

            // 确保新生成的对象没有不必要的旋转
            newBottle.transform.rotation = Quaternion.identity;

            Debug.Log("Bottle spawned at: " + spawnPosition);
        }
    }
}
