using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button imageButton;

    void Start()
    {
        int pos = GameManager.instance.stageNo;

        GameManager.instance.totalScore += GameManager.instance.gameScore;

        GameManager.instance.InitValues(pos);
        
        AudioBgm.instance.AudioPlay(1);

        imageButton.onClick.AddListener(OnNextClick);
    }
    void OnNextClick()
    {
        Debug.Log("Image clicked!");
        SceneManager.LoadScene("MainScene");
    }
}
