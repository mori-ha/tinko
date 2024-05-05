using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // コルーチンなどのためのコレクション機能

public class BattingChoice : MonoBehaviour
{
    // 打席選択フラグ
    private bool isBattingSideChosen = false;
    
    // ボタンの参照
    public GameObject leftButton;
    public GameObject rightButton;

    public IEnumerator MoveBallRepeatedly() 
    {
        // ここでボールの動きなどを定義
        yield return null; // サンプルとして空のコルーチン
    }

    public void ChooseBattingSide(string side)
    {
        if (!isBattingSideChosen)
        {
            Debug.Log(side + " 打席が選択されました。");
            isBattingSideChosen = true;

            if (leftButton != null) 
            {
                leftButton.SetActive(false);
            }
            else 
            {
                Debug.LogWarning("左ボタンが見つかりません。");
            }

            if (rightButton != null) 
            {
                rightButton.SetActive(false);
            }
            else 
            {
                Debug.LogWarning("右ボタンが見つかりません。");
            }

            StartCoroutine(MoveBallRepeatedly());
        }
    }
}


/*using UnityEngine;
using UnityEngine.UI;  // UI関連の機能を使用するために必要


public class BattingChoice : MonoBehaviour
{
    // 打席選択フラグ
    private bool isBattingSideChosen = false;
    
    // ボタンの参照
    public GameObject leftButton;
    public GameObject rightButton;

     public void ChooseBattingSide(string side)
    {
        if (!isBattingSideChosen)
        {
            Debug.Log(side + " 打席が選択されました。");
            isBattingSideChosen = true;

            StartCoroutine(MoveBallRepeatedly());
            // ボタンを確実に非表示にする
            if (leftButton != null) leftButton.SetActive(false);
            if (rightButton != null) rightButton.SetActive(false);
            
           
        }
    }
    public void ChooseBattingSide(string side)
    {
        
        if (side == "left")
        {
            Debug.Log("左打席が選択されました。");
            // 左打席用の設定をここに追加
        }
        else if (side == "right")
        {
            Debug.Log("右打席が選択されました。");
            // 右打席用の設定をここに追加
        }
    }
}*/

