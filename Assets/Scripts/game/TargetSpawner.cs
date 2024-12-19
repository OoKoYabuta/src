using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;  // ターゲットのPrefab
    public float spawnInterval = 1.0f;  // ターゲットが出現する間隔
    public Vector3 spawnAreaMin;  // スポーンエリアの最小位置
    public Vector3 spawnAreaMax;  // スポーンエリアの最大位置

    public int iKind = 0;

    public GameObject basePos;

    private float timer;

    private void Start()
    {
        if (iKind == 0)
        {
            spawnInterval = GameManager.instance.tgInterval;
        }
        else if(iKind == 1)
        {
            spawnInterval = GameManager.instance.tgNgInterval;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && GameManager.instance.GameStatus == (int)Status.start)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    void SpawnTarget()
    {
        // スポーンエリア内のランダムな位置を計算
        float xPos = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float yPos = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float zPos = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);
        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        // スケールを固定値にする
        target.transform.localScale = new Vector3(3.0f, 3.0f, 0.1f);

        // メインカメラの親に設定することでカメラを中心座標からランダムな値で出す
        if (basePos != null)
        {
            target.transform.SetParent(basePos.transform);  // 親に設定
        }

    }
}
