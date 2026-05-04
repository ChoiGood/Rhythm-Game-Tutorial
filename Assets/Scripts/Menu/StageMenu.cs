using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;
}


public class StageMenu : MonoBehaviour
{
    [SerializeField] private Song[] songList;

    [SerializeField] private TextMeshProUGUI txtSongName;
    [SerializeField] private TextMeshProUGUI txtSongComposer;
    [SerializeField] private TextMeshProUGUI txtSongScore;
    [SerializeField] private Image imgDisk;

    [SerializeField] private GameObject TitleMenu;

    DatabaseManager theDatabase;

    private int currentSong = 0;

    private void OnEnable()
    {
        if (theDatabase == null)
            theDatabase = FindObjectOfType<DatabaseManager>();
        SettingSong();
    }

    public void BttnNext()
    {
        AudioManager.instance.PlaySFX("Touch");

        if (++currentSong > songList.Length - 1)
            currentSong = 0;
        SettingSong();
    }

    public void BtnPrior()
    {
        AudioManager.instance.PlaySFX("Touch");

        if (--currentSong < 0)
            currentSong = songList.Length - 1;
        SettingSong();
    }

    void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        txtSongScore.text = string.Format("{0:#,##0}", theDatabase.score[currentSong]);
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + currentSong);
    }

    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        int t_bpm = songList[currentSong].bpm;


        GameManager.instance.GameStart(currentSong, t_bpm);
        this.gameObject.SetActive(false);
    }
}
