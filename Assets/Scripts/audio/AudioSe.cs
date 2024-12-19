using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オーディオ(SE)管理クラス : AudioSe
public class AudioSe : MonoBehaviour
{
    // オーディオリスト(SE)
    public List<AudioClip> audioClipList;

    private AudioSource audioSource;
    // ゲームマネージャーインスタンス制御
    public static AudioSe instance = null;

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

    // SE再生処理
    // 引数 : iIndex ・・・ 再生番号
    // 戻り値 : なし
    public void AudioPlay(int iIndex){
        audioSource.clip = audioClipList[iIndex];
        audioSource.Play ();
    }
}
