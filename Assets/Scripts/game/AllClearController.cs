using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllClearController : MonoBehaviour
{
    public Button imageButton;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.totalScore += GameManager.instance.gameScore;

        GameManager.instance.InitValues(0);

        AudioBgm.instance.AudioPlay(3);

        imageButton.onClick.AddListener(OnTitelClick);
   }
    void OnTitelClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
