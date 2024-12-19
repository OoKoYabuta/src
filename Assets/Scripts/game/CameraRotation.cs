using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;  // 回転の中心となるターゲット（例えば(0,0,0)）
    public float rotationSpeedY = 10f;  // 回転速度

    public float rotationSpeedX = 5f;  // 回転速度

    public int rotationYFlg = 0;

    public int rotationXFlg = 0;

    public float zoomSpeed = 1;
    
    private float timeSinceLastSwitch = 0f;  // 最後に回転軸を切り替えた時間
    public float switchInterval = 2f;  // 回転軸を切り替える間隔（秒
    private int currentRotationAxis = 0;  // 0: Y軸回転、1: X軸回転

    private void Start()
    {

        rotationYFlg    = GameManager.instance.rotYFlg;
        rotationSpeedY  = GameManager.instance.rotYSeepd;
        rotationXFlg    = GameManager.instance.rotXFlg;
        rotationSpeedX  = GameManager.instance.rotXSeepd;
        switchInterval  = GameManager.instance.rotSwInterval;

        switch (rotationYFlg,rotationXFlg)
        {
            case (3, 3):
            case (4, 4):
            case (3, 4):
            case (4, 3):
                currentRotationAxis = 0;
                break;
            case (5, 5):
            case (6, 6):
            case (5, 6):
            case (6, 5):
                currentRotationAxis = 1;
                break;            
        }
    }

    void Update()
    {
        if (GameManager.instance.GameStatus == (int)Status.start)
        {
            // 回転切り替えモードの場合
            if(rotationYFlg > 2 && rotationXFlg > 2 ){
                
                // インターバル時間を計測
                timeSinceLastSwitch += Time.deltaTime;
                
                // 切り替えタイミングの場合
                if (timeSinceLastSwitch >= switchInterval)
                {
                    // 切り替え
                    currentRotationAxis = 1 - currentRotationAxis;
                    // 計測時間をクリア
                    timeSinceLastSwitch = 0f;
                }

                if (currentRotationAxis == 0) // Y軸回転
                {
                    // 3 : 回転切り替えモード(Y軸始め - Vector3.up）
                    // 5 : 回転切り替えモード(X軸始め - Vector3.up）
                    if(rotationYFlg == 3 || rotationYFlg == 5){
                        transform.RotateAround(target.position, Vector3.up, rotationSpeedY * Time.deltaTime);
                    } 
                    // 4 : 回転切り替えモード(Y軸始め - Vector3.down）
                    // 6 : 回転切り替えモード(X軸始め - Vector3.down）
                    else if(rotationYFlg == 4 || rotationYFlg == 6){
                        transform.RotateAround(target.position, Vector3.down , rotationSpeedY * Time.deltaTime);
                    }
                }
                else if (currentRotationAxis == 1) // X軸回転
                {
                    // 3：回転切り替えモード(Y軸始め - Vector3.right）
                    // 5：回転切り替えモード(X軸始め - Vector3.right）
                    if(rotationXFlg == 3 || rotationXFlg == 5){
                        transform.RotateAround(target.position, Vector3.right, rotationSpeedX * Time.deltaTime);
                    }
                    // 4：回転切り替えモード(Y軸始め - Vector3.left）
                    // 6：回転切り替えモード(X軸始め - Vector3.left）
                    else if(rotationXFlg == 4 || rotationXFlg == 6){
                        transform.RotateAround(target.position, Vector3.left, rotationSpeedX * Time.deltaTime);
                    }
                }
            }
            // そうでない場合
            else {
                // 回転軸を指定してカメラを回転させる (ここではY軸を使用)
                if (rotationYFlg == 1) { 
                    transform.RotateAround(target.position, Vector3.up, rotationSpeedY * Time.deltaTime);
                } else if(rotationYFlg == 2) {
                    transform.RotateAround(target.position, Vector3.down, rotationSpeedY * Time.deltaTime);                    
                }
                // 回転軸を指定してカメラを回転させる (ここではX軸を使用)
                if(rotationXFlg == 1)
                {   
                    transform.RotateAround(target.position, Vector3.right, rotationSpeedX * Time.deltaTime);
                } else if(rotationXFlg == 2){
                    transform.RotateAround(target.position, Vector3.left, rotationSpeedX * Time.deltaTime);
                }
            }

            transform.LookAt(target.transform);
        }
        var scroll = Input.mouseScrollDelta.y;
        transform.position += -transform.forward * scroll * zoomSpeed;
    }
}
