using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [SerializeField] private GameObject goComboImage;
    [SerializeField] private Text textCombo;

    private int currentCombo = 0;
    public int CurrentCombo => currentCombo;

    private Animator comboUpAnimator;
    private static readonly int ComboUpHash = Animator.StringToHash("ComboUp");  // 최적화를 위해 StringToHash 를 사용


    void Start()
    {
        comboUpAnimator = GetComponent<Animator>();
        ResetCombo();
    }

    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        textCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (currentCombo > 2)
        {
            textCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);

            comboUpAnimator.SetTrigger(ComboUpHash);    
        }
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        textCombo.text = "0";
        textCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    
}
