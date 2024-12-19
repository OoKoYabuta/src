using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // カメラの回転を取得
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // カメラの回転をEuler角に変換（必要な軸の回転を取得）
        Vector3 eulerAngles = cameraRotation.eulerAngles;

        // Y軸（水平軸）の回転角度を取得
        float yRotation = eulerAngles.y;

        // X軸（垂直軸）の回転角度を取得
        float xRotation = eulerAngles.x;

        // Y軸の補正（0度または180度に補正）
        if (yRotation > 90f && yRotation < 270f)
        {
            // 0度に補正
            yRotation = 0f;
        }
        else
        {
            // 180度に補正
            yRotation = 180f;
        }

        // X軸の補正（0度または180度に補正）
        if (xRotation > 90f && xRotation < 270f)
        {
            // 0度に補正
            xRotation = 0f;
        }
        else
        {
            // 180度に補正
            xRotation = 180f;
        }

        // X軸とY軸を補正した回転を適用
        this.gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public void OnMouseDown()
    {
        // Debug.Log(GameManager.instance.stageNo);
        Debug.Log("OnMouseDown");
        Instantiate(particle,transform.position,transform.rotation);
        Destroy(this.gameObject);
        GameManager.instance.gameScore += 10;
        AudioSe.instance.AudioPlay(0);
    }

}
