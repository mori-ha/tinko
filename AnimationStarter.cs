using UnityEngine;
using System.Collections; // コルーチンを使用するために必要

public class AnimationStarter : MonoBehaviour
{
    public Animator animator;  // アニメーターの参照
    public string animationBoolName = "mc";  // アニメーションのトリガー名

    // ボタンをクリックしたときに呼び出される関数
    public void StartAnimation()
    {
        if (animator != null)
        {
            StartCoroutine(DelayedStart(3));  // 3秒後にアニメーションを開始するコルーチンを呼び出す
        }
        else
        {
            Debug.LogError("Animator が見つかりません。");
        }
    }

    // 指定された秒数後にアニメーションを開始するコルーチン
    IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);  // 指定された時間（秒）待機
        animator.SetTrigger(animationBoolName, true);  // アニメーションを開始する
    }
}


/*using UnityEngine;

public class AnimationStarter : MonoBehaviour
{
    public Animator animator;  // アニメーターの参照
    public string animationTriggerName = "StartAnimation";  // アニメーションのトリガー名

    // ボタンをクリックしたときに呼び出される関数
    public void StartAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);  // アニメーションを開始する
        }
        else
        {
            Debug.LogError("Animator が見つかりません。");
        }
    }
}*/
