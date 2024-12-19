using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [SerializeField]
    private List<Material> skyboxList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkybox();
    }

    void UpdateSkybox()
    {
        switch (GameManager.instance.stageNo % 2,GameManager.instance.stageNo % 5)
        {
            // 偶数かつ 5 で割り切れる場合
            case (0, 0):
                RenderSettings.skybox = skyboxList[2];
                break;
            // 偶数だが 5 で割り切れない場合
            case (0, _):
                RenderSettings.skybox = skyboxList[1];
                break;
            // 奇数かつ 5 で割り切れる場合
            case (1, 0):
                RenderSettings.skybox = skyboxList[3];
                break;
            // 奇数かつ 5 で割り切れない場合
             case (1, _):
                RenderSettings.skybox = skyboxList[0];
                break;
            default:
                Debug.LogWarning("未定義のステージです");
                break;
        }

        // Skyboxが変更された際に再レンダリングを行う
        DynamicGI.UpdateEnvironment();
    }

}
