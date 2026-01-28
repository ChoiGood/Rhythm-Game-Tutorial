using UnityEngine;

public class NoteManager : MonoBehaviour
{

    public int bpm = 0; // beat per minute : 1분당 비트 수
    private double currentTime = 0d; // 노드 생성을 위한 시간을 체크할 변수  => 리듬 게임에선 아주 사소한 오차라도 문제가 생기기 떄문에 float 보다 오차가 더 작은 double 로 선언

    [SerializeField] private Transform tfNoteAppear = null;  // 노트가 생성될 위치 변수
    [SerializeField] private GameObject goNote = null;       // 노드 프리펩을 담을 변수 

    TimingManager theTimingManager;
    EffectManager theEffectManager;

    private void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            // if (!collision.GetComponent<Note>().IsHit)  으로 사용해도 되게 만들어는 뒀는데, 로직은 튜토리얼과 같이 가는게 좋을거같아서 이렇게 둠
            if (collision.GetComponent<Note>().GetNoteFlag())
                theEffectManager.JudgementEffect(4);
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
