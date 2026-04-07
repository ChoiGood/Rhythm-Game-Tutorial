using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] goGameUI;
    [SerializeField] private GameObject goTitleUI;

    public static GameManager instance;

    public bool isStartGame = false;

    private void Start()
    {
        instance = this;
    }

    public void GameStart()
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        isStartGame = true;
    }

    public void MainMenu()
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }
        // isStartGame = false;
        goTitleUI.SetActive(true);
    }
}
