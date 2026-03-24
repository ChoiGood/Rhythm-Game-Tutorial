using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class StatusManager : MonoBehaviour
{
    [SerializeField] private float blinkSpeed = 0.1f;
    [SerializeField] private int blinkCount = 10;
    private int currentBlinkCount = 0;
    private bool isBlink = false;

    private bool isDead = false;

    private int maxHp = 3;
    private int currentHp = 3;

    private int maxShield = 3;
    private int currentShield = 0;

    [SerializeField] private Image[] hpImage;
    [SerializeField] private Image[] shieldImage;

    [SerializeField] private int shieldIncreaseCombo = 5;
    private int currentShieldCombo = 0;
    [SerializeField] private Image shieldGauge;


    [SerializeField] private MeshRenderer playerMesh;
    Result theResult;
    NoteManager theNote;

    private void Start()
    {
        theResult = FindObjectOfType<Result>();
        theNote = FindObjectOfType<NoteManager>();
    }

    public void CheckShield()
    {
        currentShieldCombo++;

        if (currentShieldCombo >= shieldIncreaseCombo)
        {
            currentShieldCombo = 0;
            IncreaseShield();
        }

        shieldGauge.fillAmount = (float)currentShieldCombo / shieldIncreaseCombo;
    }

    public void ResetShieldCombo()
    {
        currentShieldCombo = 0;
        shieldGauge.fillAmount = (float)currentShieldCombo / shieldIncreaseCombo;
    }

    public void IncreaseShield()
    {
        currentShield++;

        if (currentShield >= maxShield)
            currentShield = maxShield;

        SettingShieldImage();
    }

    public void DecreaseShield(int p_num)
    {
        currentShield -= p_num;

        if (currentShield <= 0)
            currentShield = 0;

        SettingShieldImage();
    }

    public void IncreaseHP(int p_num)
    {
        currentHp += p_num;
        if (currentHp >= maxHp)
            currentHp = maxHp;

        SettingHPImage();
    }

    public void DecreaseHp(int p_num)
    {
        if (!isBlink)
        {
            if (currentShield > 0)
            {
                DecreaseShield(p_num);
            }
            else
            {
                currentHp -= p_num;

                if (currentHp <= 0)
                {
                    isDead = true;
                    theResult.ShowResult();
                    theNote.RemoveNote();
                }
                else
                {
                    StartCoroutine(BlinkCo());
                }

                SettingHPImage();
            }
        }
    }

    private void SettingHPImage()
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            if (i < currentHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false);
        }
    }

    private void SettingShieldImage()
    {
        for (int i = 0; i < shieldImage.Length; i++)
        {
            if (i < currentShield)
                shieldImage[i].gameObject.SetActive(true);
            else
                shieldImage[i].gameObject.SetActive(false);
        }
    }

    public bool IsDead => isDead;

    IEnumerator BlinkCo()
    {
        isBlink = true;

        while (currentBlinkCount <= blinkCount)
        {
            playerMesh.enabled = !playerMesh.enabled;
            yield return new WaitForSeconds(blinkSpeed);
            currentBlinkCount++;
        }

        playerMesh.enabled = true;
        currentBlinkCount = 0;
        isBlink = false;
    }
}
