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
            // �R���\�[���ł͏I�����Ȃ����߁AUnity�G�f�B�^���ǂ����̃`�F�b�N������Ɨǂ�
#if UNITY_EDITOR
            // �G�f�B�^�̏ꍇ�͏I�����Ȃ�
            UnityEditor.EditorApplication.isPlaying = false;
#else
                // �r���h���ꂽ�A�v���P�[�V�������I��
                Application.Quit();
#endif
        }
    }
}
