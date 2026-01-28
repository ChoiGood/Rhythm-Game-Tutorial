using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    [Header("Hit Effect")]
    [SerializeField] private Animator noteHitAnimator;

    [Header("Judgement Effect")]
    [SerializeField] private Animator judgementAnimator;
    [SerializeField] private Image judgementImage;
    [SerializeField] private Sprite[] judgementSprites;

    // Animator Hashes
    private static readonly int HitHash = Animator.StringToHash("Hit");  // 최적화를 위해 StringToHash 를 사용

    public void JudgementEffect(int judgementIndex)
    {
        judgementImage.sprite = judgementSprites[judgementIndex];    // 파라미터 값에 맞는 판정 이미지 스프라이트로 교체
        judgementAnimator.SetTrigger(HitHash);
    }

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(HitHash);
    }
}
