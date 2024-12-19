using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private TextMeshProUGUI tmTotalText;

    // Update is called once per frame
    void Update()
    {
        string txt = "TotalScore[ " + GameManager.instance.totalScore.ToString() + " ]";
        if(tmTotalText.text != txt){
            tmTotalText.text = txt;
        } 
    }
}
