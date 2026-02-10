using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private int baseScore = 10;
    [SerializeField] private float[] weight;
    
    private int currentScore = 0;
    private Animator scoreUpAnimator;

    private static readonly int ScoreUpHash = Animator.StringToHash("ScoreUp");  // 최적화를 위해 StringToHash 를 사용


    void Start()
    {
        scoreUpAnimator = GetComponent<Animator>();
        ResetScore();
    }

    public void IncreaseScore(int judgementIndex)
    {
        // indxx 예외 처리 코드 (필요시 사용)
        // judgementIndex = Mathf.Clamp(judgementIndex, 0, weight.Length - 1);

        // 가중치 계산
        int increaseAmount = (int)(baseScore * weight[judgementIndex]);

        currentScore += increaseAmount;
        UpdateSWcoreUI();
        

        scoreUpAnimator.SetTrigger(ScoreUpHash);
    }

    void ResetScore()
    {
        currentScore = 0;
        textScore.text = "0";
    }

    void UpdateSWcoreUI()
    {
        textScore.text = $"{currentScore:#,##0}";                       //  string 출력 방법 : 문자열 보간 
        // textScore.text = string.Format("{0:#,##0}", currentScore);  // string 출력 방법 : String.Format 메서드 사용
    }

    public int CurrentScore => currentScore;

}
