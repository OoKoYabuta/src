using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmInfoText;

	private int countdownStartValue = 3;

    void Start () {
        if( GameManager.instance.infoTextFlg ){
        	StartCoroutine(AnimationText());
		} 
    }

    void Update()
    {
		
    }

    private IEnumerator AnimationText()
	{
		float a_col = 1;
		var colortemp = tmInfoText.color;
        
        tmInfoText.text =   "Stage [ " + GameManager.instance.stageNo.ToString() + " ] ClearScore [ " + GameManager.instance.clearScore.ToString() + " ]";

		while (GameManager.instance.infoTextFlg)
		{
			tmInfoText.color = new Color(colortemp.r, colortemp.g, colortemp.b, a_col);
			a_col -= Time.deltaTime * 0.25f ;
			yield return new WaitForEndOfFrame();
			if (a_col < 0)
			{
				a_col = 0;
				GameManager.instance.infoTextFlg = false;
				GameManager.instance.startCntFlg = true;
			}
		}
        int currentValue = countdownStartValue;

        tmInfoText.color = new Color(colortemp.r, colortemp.g, colortemp.b, 255);

        while (GameManager.instance.startCntFlg)
		{
            tmInfoText.text = currentValue.ToString();  // 現在のカウントを表示
            yield return new WaitForSeconds(1f);  // 1秒待つ
            currentValue--;  // 1減らす
            if(currentValue <= 0){
                GameManager.instance.startCntFlg = false;
            }
        }

        tmInfoText.color = new Color(colortemp.r, colortemp.g, colortemp.b, 0);
        
        OnCountdownFinished();
	}

    // カウントダウン終了後の処理
    void OnCountdownFinished()
    {
        Debug.Log("Countdown finished!");
        // カウントダウン終了後にゲーム開始などの処理を追加
		GameManager.instance.GameStatus = (int)Status.start;
        AudioBgm.instance.AudioPlayStageNo();
    }

}
