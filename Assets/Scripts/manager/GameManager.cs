using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.TextCore.Text;

enum Status:int {
    idle = 0,
    start,
    clear,
    end
}

public class StageCommon
{
    public int      clearScore;     // クリア条件
    public float    limitTimer;     // 制限時間
    public int      stageNo;        // ステージNO
    public int      rotationYFlg;   // 回転(Y軸)
    public float    rotationYSeepd; // 回転速度(Y軸)
    public int      rotationXFlg;   // 回転(Y軸)
    public float    rotationXSeepd; // 回転速度(Y軸)
    public float    rotationSwInterval; // 回転切り替えインターバル
    public float    targetInterval;     // ターゲット(正解)の表示インターバル
    public float    targetNgInterval;   // ターゲット(不正解)の表示インターバル
}

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public string filePath = Application.dataPath + "/Resources/stage.csv";

    public List<StageCommon> liStages;

    public int      stageNo;       // ステージNO

    public int      clearScore;    // クリアスコア

    public int      totalScore;    // 総スコア

    public int      maxStage;      // 最大ステージ数

    public float    limitTimer;    // 制限時間

    public int      rotYFlg;       // 回転(Y軸)
    public float    rotYSeepd;     // 回転速度(Y軸)
    public int      rotXFlg;       // 回転(Y軸)
    public float    rotXSeepd;     // 回転速度(Y軸)
    public float    rotSwInterval; // 回転切り替えインターバル時間
    public float    tgInterval;    // ターゲット(正解)の表示インターバル
    public float    tgNgInterval;  // ターゲット(不正解)の表示インターバル

    private int     gameStatus;    // 状態ステータス

    public int GameStatus {
        get { return gameStatus; }  // getterの部分
        set { gameStatus = value; } // setterの部分
    }

    public bool infoTextFlg;    // 情報テキスト表示フラグ

    public bool startCntFlg;    // スタートカウント表示フラグ

    public int gameScore;       // ゲームスコア

    private void Awake()
    {
        liStages = new List<StageCommon>();

        ReadCSV(filePath);

        InitValues(0);

        maxStage = liStages.Count;

        totalScore = 0;
    }

    public void UpdateGameStatus(int value){
        this.gameStatus = value;
    }

    private void ReadCSV(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            StageCommon stageCom    = new StageCommon();
            stageCom.clearScore     = int.Parse(values[0]);
            stageCom.limitTimer     = float.Parse(values[1]);
            stageCom.stageNo        = int.Parse(values[2]);
            stageCom.rotationYFlg   = int.Parse(values[3]);
            stageCom.rotationYSeepd = float.Parse(values[4]);
            stageCom.rotationXFlg   = int.Parse(values[5]);
            stageCom.rotationXSeepd = float.Parse(values[6]);
            stageCom.rotationSwInterval = float.Parse(values[7]);
            stageCom.targetInterval     = float.Parse(values[8]);
            stageCom.targetNgInterval   = float.Parse(values[9]);

            liStages.Add(stageCom);
        }
        reader.Close();
    }

    public void InitValues(int iPos){

        gameScore       = 0;

        GameStatus      = (int)Status.idle;

        infoTextFlg     = true;

        startCntFlg     = false;

        clearScore      = liStages[iPos].clearScore;

        limitTimer      = liStages[iPos].limitTimer;

        stageNo         = liStages[iPos].stageNo;

        rotYFlg         = liStages[iPos].rotationYFlg;   // 回転(Y軸)

        rotYSeepd       = liStages[iPos].rotationYSeepd; // 回転速度(Y軸)

        rotXFlg         = liStages[iPos].rotationXFlg;   // 回転(Y軸)

        rotXSeepd       = liStages[iPos].rotationXSeepd; // 回転速度(Y軸)

        rotSwInterval   = liStages[iPos].rotationSwInterval;// 回転切り替えインターバル時間

        tgInterval      = liStages[iPos].targetInterval;    // ターゲット(正解)の表示インターバル

        tgNgInterval    = liStages[iPos].targetNgInterval;  // ターゲット(不正解)の表示インターバル

    }

}
