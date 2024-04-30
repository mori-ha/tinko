using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // UI コンポーネントを使用するために必要

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    private Rigidbody rb;

    // ストライクゾーンの座標の範囲
    public float strikeZoneMinX = -0.9f;
    public float strikeZoneMaxX = -0.1f;
    public float strikeZoneMinY = -1.5f;
    public float strikeZoneMaxY = 1.0f;

    // 打席選択フラグ
    private bool isBattingSideChosen = false;

    // ボタンの参照
    public GameObject leftButton;
    public GameObject rightButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // タグを使用してボタンを見つける
        leftButton = GameObject.FindWithTag("LeftButton");
        rightButton = GameObject.FindWithTag("RightButton");
    }

    private IEnumerator MoveBallRepeatedly()
    {
        yield return new WaitForSeconds(5);  // 5秒の遅延を追加

        for (int i = 0; i < repeatCount; i++)
        {
            float targetX = Random.Range(strikeZoneMinX, strikeZoneMaxX);
            float targetY = Random.Range(strikeZoneMinY, strikeZoneMaxY);
            Vector3 targetPosition = new Vector3(targetX, targetY, 0);
            Vector3 direction = (targetPosition - transform.position).normalized;

            float speedInMetersPerSecond = 150 * 1000 / 3600;
            rb.velocity = direction * speedInMetersPerSecond;

            yield return new WaitForSeconds(interval + 1.38f);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(-0.7f, 2, 18);
        }
    }

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
}


/*using UnityEngine;
using System.Collections;

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    private Rigidbody rb;
    // ストライクゾーンのy座標の範囲
    public float strikeZoneMinX = -0.9f;
    public float strikeZoneMaxX = -0.1f;
    public float strikeZoneMinY = -1.5f;
    public float strikeZoneMaxY = 1.0f;

    // 打席選択フラグ
    private bool isBattingSideChosen = false;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // コルーチンの開始を選択後に変更するため、Startから削除
    }

    private IEnumerator MoveBallRepeatedly()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            // ストライクゾーン内でランダムな目標位置を生成
            float targetX = Random.Range(strikeZoneMinX, strikeZoneMaxX);
            float targetY = Random.Range(strikeZoneMinY, strikeZoneMaxY);
        
            Vector3 targetPosition = new Vector3(targetX, targetY, 0); // z=0に設定

            // ボールの初期位置から目標位置までの方向ベクトルを計算
            Vector3 direction = (targetPosition - transform.position).normalized;

            // 方向と速度を調整
            float speedInMetersPerSecond = 150 * 1000 / 3600;
            rb.velocity = direction * speedInMetersPerSecond;

            // 指定した間隔で待機
            yield return new WaitForSeconds(interval + 1.38f);

            // ボールの位置と速度をリセット
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(-0.7f, 2, 18);
        }
    }

    // 打席選択用メソッド追加
    public void ChooseBattingSide(string side)
    {
        if (!isBattingSideChosen)
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
            isBattingSideChosen = true;

            
            StartCoroutine(MoveBallRepeatedly()); // 打席が選択された後、ボールを動かし始める
        }
    }
}*/


/*using UnityEngine;
using System.Collections;

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    private Rigidbody rb;
    // ストライクゾーンのy座標の範囲
    public float strikeZoneMinX = -0.9f;
    public float strikeZoneMaxX = -0.1f;
    
    public float strikeZoneMinY = -1.5f;
    public float strikeZoneMaxY = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveBallRepeatedly());
    }

    private IEnumerator MoveBallRepeatedly()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            // ストライクゾーン内でランダムな目標位置を生成
            float targetX = Random.Range(strikeZoneMinX, strikeZoneMaxX);
            float targetY = Random.Range(strikeZoneMinY, strikeZoneMaxY);
        
            Vector3 targetPosition = new Vector3(targetX, targetY, 0); // z=0に設定

            // ボールの初期位置から目標位置までの方向ベクトルを計算
            Vector3 direction = (targetPosition - transform.position).normalized;

            // 方向と速度を調整
            float speedInMetersPerSecond = 150 * 1000 / 3600;
            rb.velocity = direction * speedInMetersPerSecond;

            // 指定した間隔で待機
            yield return new WaitForSeconds(interval+1.38f);

            // ボールの位置と速度をリセット
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(-0.7f, 2, 18);
        }
    }
}*/


