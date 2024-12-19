using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float fGameTime;
    private float fCurrentTime;
    [SerializeField]
    private TextMeshProUGUI tmTimeText;

    // Start is called before the first frame update
    void Start()
    {
        fCurrentTime = GameManager.instance.limitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        // スタート状態なら
        if (GameManager.instance.GameStatus == (int)Status.start)
        {
            fCurrentTime -= Time.deltaTime;

            if (fCurrentTime < 0.0f){

                GameManager.instance.GameStatus = (int)Status.end;

                SceneManager.LoadScene("GameOverScene");
            
            }
            tmTimeText.text = Mathf.Ceil(fCurrentTime).ToString();
        }
        // それ以外なら

    }
}
