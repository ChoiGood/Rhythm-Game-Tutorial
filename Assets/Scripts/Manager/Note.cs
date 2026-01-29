using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;
    public bool IsHit { get; private set; }

    private Image noteImage;

    private void OnEnable()
    {
        if (noteImage == null)
            noteImage = GetComponent<Image>();

        noteImage.enabled = true;
    }
    
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    //public void Hit()
    //{
    //    if (IsHit) return;

    //    IsHit = true;
    //    HideNote();
    //}

    public void HideNote()
    {
        IsHit = true;
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }

    // 위 두개의 함수를 보고 아래와 같이 프로퍼티로 작성하는게 더 C# 스럽지않나라고 생각해서 이렇게 만들었으나.. Hit 로 상태 관리하는게 더 좋아보인다고 최종 결정
    /*public bool IsVisible
    {
        get => noteImage.enabled;
        set => noteImage.enabled = value;
    }*/


}
