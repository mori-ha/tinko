using UnityEngine;

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
}
