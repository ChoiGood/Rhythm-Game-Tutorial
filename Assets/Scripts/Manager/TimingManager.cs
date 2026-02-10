using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();           // 생성된 노트를 담는 List  => 판정 범위에 있는 지 모든 노트를 비교해야한다.
    
    [SerializeField] private Transform Center = null;                       
    [SerializeField] private RectTransform[] timingRect = null;            // 판정 범위 (Perfect, Cool, Good, Bad) 판단를 위한 RectTransform 배열
    Vector2[] timingBoxs = null;                                            // 판정 범위의 최솟값(x), 최댓값(y)

    EffectManager theEffect;
    ScoreManager theScoreManager;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();

        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x <timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    // 노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // 이펙트 연출
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();
                    theEffect.JudgementEffect(x);

                    // 점수 증가
                    theScoreManager.IncreaseScore(x);
                    return;
                }
            }
        }

        theEffect.JudgementEffect(timingBoxs.Length);   // timingBoxs의 배열 개수는 4 이므로 length를 이용해도 됨!
    }

    
}
