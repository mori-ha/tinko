using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    public float forceAmount = 10.0f;
    public float torqueAmount = 5.0f;
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
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on " + gameObject.name);
        }

        leftButton = GameObject.FindWithTag("LeftButton");
        rightButton = GameObject.FindWithTag("RightButton");

        if (leftButton == null || rightButton == null)
        {
            Debug.LogError("One or both buttons could not be found. Check the tags.");
        }
    }

    private IEnumerator MoveBallRepeatedly()
    {
        yield return new WaitForSeconds(5);  // Initial delay before starting the pitches.

        for (int i = 0; i < repeatCount; i++)
        {
            if (rb == null)
            {
                Debug.LogError("Rigidbody is null, aborting ball movement.");
                yield break;
            }

            float targetX = Random.Range(strikeZoneMinX, strikeZoneMaxX);
            float targetY = Random.Range(strikeZoneMinY, strikeZoneMaxY);
            Vector3 targetPosition = new Vector3(targetX, targetY, 0);
            Vector3 direction = (targetPosition - transform.position).normalized;

            float speedInMetersPerSecond = (i == 0 ? 150 : 130) * 1000 / 3600;  // Speed calculation
            rb.velocity = direction * speedInMetersPerSecond;

            yield return new WaitForSeconds(interval + 2.9f);  // Wait for the next pitch

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(-0.7f, 2, 18);  // Reset position after each pitch
        }
    }

    public void ChooseBattingSide(string side)
    {
        if (!isBattingSideChosen)
        {
            Debug.Log(side + " batting side chosen.");
            isBattingSideChosen = true;

            StartCoroutine(MoveBallRepeatedly());
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
    }
}



/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    public float forceAmount = 10.0f;
    public float torqueAmount = 5.0f;
    private Rigidbody rb;

    public float strikeZoneMinX = -0.9f;
    public float strikeZoneMaxX = -0.1f;
    public float strikeZoneMinY = -1.5f;
    public float strikeZoneMaxY = 1.0f;

    private bool isBattingSideChosen = false;
    public GameObject leftButton;
    public GameObject rightButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leftButton = GameObject.FindWithTag("LeftButton");
        rightButton = GameObject.FindWithTag("RightButton");
    }

    private IEnumerator MoveBallRepeatedly()
    {
        yield return new WaitForSeconds(5);

        for (int i = 0; i < repeatCount; i++)
        {
            float targetX = Random.Range(strikeZoneMinX, strikeZoneMaxX);
            float targetY = Random.Range(strikeZoneMinY, strikeZoneMaxY);
            Vector3 targetPosition = new Vector3(targetX, targetY, 0);
            Vector3 direction = (targetPosition - transform.position).normalized;

            float speed = (i == 0 ? 150 : 130);  // 1球目150km/h, 2球目130km/h
            float speedInMetersPerSecond = speed * 1000 / 3600;  // km/h to m/s
            rb.velocity = direction * speedInMetersPerSecond;

            if (i == 0)
                rb.velocity = direction * speedInMetersPerSecond;  // ストレート
            else if (i == 1)
                ThrowCurveBall(speedInMetersPerSecond);  // カーブ

            yield return new WaitForSeconds(interval * 1 + 2.9f);

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
            if (leftButton != null) leftButton.SetActive(false);
            if (rightButton != null) rightButton.SetActive(false);
        }
    }

    public void ThrowCurveBall(float speed)
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);  // カーブの基本力
        rb.AddTorque(transform.up * torqueAmount, ForceMode.Impulse);  // カーブさせるためのトルク
    }

    public void ThrowForkBall(float speed)
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);  // フォークの基本力
        rb.AddForce(-transform.up * torqueAmount, ForceMode.Impulse);  // 下向きの力
    }
}*/

/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // UI コンポーネントを使用するために必要

public class BallMover : MonoBehaviour
{
    public int repeatCount = 10;
    public float interval = 0.8f;
    /*public float forceAmount = 10.0f;
    public float torqueAmount = 5.0f;
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

            yield return new WaitForSeconds(interval + 2.9f);

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

    /*public void ThrowCurveBall()
    {
        // 前方に力を加える
        rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        // カーブさせるためにトルクを加える
        rb.AddTorque(transform.up * torqueAmount, ForceMode.Impulse);
    }

    public void ThrowForkBall()
    {
        // 前方に力を加える
        rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        // フォークボール用に下向きの力を追加
        rb.AddForce(-transform.up * torqueAmount, ForceMode.Impulse);
    }
}*/


