using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] private GameObject goStageUI;

    public void BtnPlay()
    {
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
