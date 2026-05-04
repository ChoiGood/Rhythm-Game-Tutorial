using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public int[] score;

    private void Start()
    {
        LoadScore();
    }

    public void SaveScore()
    {
        // 방법 1. PlayerPrefs는
        // 키-값 쌍으로 데이터를 저장하는 시스템입니다. 배열을 직접 저장할 수 없으므로, 각 요소를 개별적으로 저장해야 합니다.
        // 데이터를 자체 기기에 저장. (앱을 지우면 복구 불가

        //PlayerPrefs.SetInt("Score1", score[0]);
        //PlayerPrefs.SetInt("Score2", score[1]);
        //PlayerPrefs.SetInt("Score3", score[2]);

        // 방법 2. 서버 통신
        BackendGameData.userData.scores = (int[])score.Clone();

        BackendGameData.Instance.GameDataUpdate();

    }

    public void LoadScore()
    {
        //if (PlayerPrefs.HasKey("Score1"))
        //{
        //    score[0] = PlayerPrefs.GetInt("Score1");
        //    score[1] = PlayerPrefs.GetInt("Score2");
        //    score[2] = PlayerPrefs.GetInt("Score3");
        //}
        
        if (BackendGameData.userData != null && BackendGameData.userData.scores != null)
        {
            score = (int[])BackendGameData.userData.scores.Clone();

            Debug.Log("서버에서 score 데이터를 불러왔습니다.");
        }

    }
}
