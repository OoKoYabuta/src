using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オーディオ(BGM)管理クラス : AudioSe
public class AudioBgm : MonoBehaviour
{
    // オーディオリスト(BGM)
    public List<AudioClip> audioClipList;

    private AudioSource audioSource;
    // ゲームマネージャーインスタンス制御
    public static AudioBgm instance = null;

    // Awake ・・・ Unity側が呼ぶ特別なメソッドであり、インスタンス化直後に呼ばれる
    //              初期化処理を記載することが多い
    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            // DontDestroyOnLoad : シーンが移動しても指定したオブジェクトは破棄されない
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // シングルトン　・・・　オブジェクト指向プログラミングにおけるクラスのデザインパターンの一つで、実行時にそのクラスのインスタンスが必ず単一になるよう設計すること
            //                     ⇒　要は絶対に１つしか存在しないものを定義する手法
            //                     [ 使用例 ] : ステージの進行状況やスコアなど
            Destroy(this.gameObject);
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // BGM再生処理
    // 引数 : iIndex ・・・ 再生番号
    // 戻り値 : なし
    public void AudioPlay(int iIndex){
        audioSource.clip = audioClipList[iIndex];
        audioSource.Play ();
    }

    // BGM停止処理
    // 引数 : なし
    // 戻り値 : なし
    public void AudioStop(){
        audioSource.Stop ();
    }

    public void AudioPlayStageNo()
    {
        switch (GameManager.instance.stageNo % 2, GameManager.instance.stageNo % 5)
        {
            // 偶数かつ 5 で割り切れる場合
            case (0, 0):
                AudioPlay(5);
                break;
            // 偶数だが 5 で割り切れない場合
            case (0, _):
                AudioPlay(4);
                break;
            // 奇数かつ 5 で割り切れる場合
            case (1, 0):
                AudioPlay(6);
                break;
            // 奇数かつ 5 で割り切れない場合
            case (1, _):
                AudioPlay(0);
                break;
            default:
                break;
        }
    }

}
