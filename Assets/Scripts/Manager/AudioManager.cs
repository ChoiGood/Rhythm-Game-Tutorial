using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private Sound[] sfx;
    [SerializeField] private Sound[] bgm;

    [SerializeField] private AudioSource bgmPlayer;
    [SerializeField] private AudioSource[] sfxPlayer;

    private void Start()
    {
        instance = this;
    }

    public void PlayBGM(string p_bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }
    
    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }

                Debug.Log("모든 오디오 플레이어가 재생중입니다.");
                return;
            }
        }

        Debug.Log(p_sfxName + "이름의 효과음이 없습니다.");
    }

}
