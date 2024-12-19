using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button imageButton;

    void Start()
    {
        GameManager.instance.totalScore = 0;

        imageButton.onClick.AddListener(OnImageClick);
    }
    void OnImageClick()
    {
        Debug.Log("Image clicked!");
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            // コンソールでは終了しないため、Unityエディタかどうかのチェックがあると良い
#if UNITY_EDITOR
            // エディタの場合は終了しない
            UnityEditor.EditorApplication.isPlaying = false;
#else
                // ビルドされたアプリケーションを終了
                Application.Quit();
#endif
        }
    }
}
