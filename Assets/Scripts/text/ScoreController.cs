using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmScoreText;

    // Start is called before the first frame update
    void Start()
    {
        tmScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        tmScoreText.text = GameManager.instance.gameScore.ToString();

        if(GameManager.instance.gameScore >= GameManager.instance.clearScore)
        {
            if (GameManager.instance.maxStage == (GameManager.instance.stageNo))
            {
                SceneManager.LoadScene("AllClearScene");
            }
            else
            {
                SceneManager.LoadScene("ClearScene");
            }
        }

    }
}
