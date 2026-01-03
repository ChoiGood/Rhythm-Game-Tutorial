using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();           // 생성된 노트를 담는 List  => 판정 범위에 있는 지 모든 노트를 비교해야한다.
    
    [SerializeField] private Transform Center = null;                       
    [SerializeField] private RectTransform[] timingRect = null;            // 판정 범위 (Perfect, Cool, Good, Bad) 판단를 위한 RectTransform 배열
    Vector2[] timingBoxs = null;                                            // 판정 범위의 최솟값(x), 최댓값(y)

    void Start()
    {
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

            for (int j = 0; j <timingBoxs.Length; j++)
            {
                if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y)
                {

                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit" + j);
                    return;
                }
            }
        }

        Debug.Log("Miss");
    }

    
}
