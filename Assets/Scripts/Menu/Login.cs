using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField id;
    [SerializeField] TMP_InputField pw;

    DatabaseManager databaseManager;
    private void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
    }
    public void BtnRegist()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendLogin.Instance.CustomSignUp(t_id, t_pw);
    }

    public void BtnLogin()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendLogin.Instance.CustomLogin(t_id, t_pw);
        
        BackendGameData.Instance.GameDataGet();

        databaseManager.LoadScore();

        this.gameObject.SetActive(false);
    }
}
