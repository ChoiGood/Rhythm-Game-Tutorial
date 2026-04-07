using UnityEngine;

public class StageMenu : MonoBehaviour
{
    [SerializeField] private GameObject TitleMenu;

    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        GameManager.instance.GameStart();
        this.gameObject.SetActive(false);
    }
}
