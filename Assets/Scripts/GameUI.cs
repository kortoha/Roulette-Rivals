using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Button pB; 
    public Button sB; 
    public Button rB; 

    public Sprite sOnS; 
    public Sprite sOffS; 

    public GameObject gP; 
    public GameObject pP; 
    public GameObject wP; 

    public Cell[] cA; 

    [SerializeField] private int _sID = 0; 

    private bool _iSOn;
    private bool _iWPA = false; 

    private void Start()
    {
        _iSOn = PlayerPrefs.GetInt("IsSoundOn", 0) == 0;

        USBS();

        sB.onClick.AddListener(TS);
        pB.onClick.AddListener(PG);
        rB.onClick.AddListener(RG);
    }

    private void Update()
    {
        if (!_iWPA && AAOCO())
        {
            Invoke(nameof(AWP), 1.5f); 
        }
    }

    private void AWP()
    {
        wP.SetActive(true);
        gP.SetActive(false);
        _iWPA = true;
    }

    private bool AAOCO()
    {
        foreach (var c in cA)
        {
            if (!c.IsOpen())
            {
                return false;
            }
        }
        return true;
    }

    private void TS()
    {
        _iSOn = !_iSOn;

        PlayerPrefs.SetInt("IsSoundOn", _iSOn ? 0 : 1);
        AudioListener.pause = _iSOn;

        USBS();
    }

    private void USBS()
    {
        sB.image.sprite = _iSOn ? sOffS : sOnS;
    }

    private void RG() 
    {
        pP.SetActive(false);
        gP.SetActive(true);
        Time.timeScale = 1;
    }

    private void PG() 
    {
        pP.SetActive(true);
        gP.SetActive(false);
        Time.timeScale = 0;
    }

    public void RST()
    {
        if (_iWPA)
        {
            MoneyManager.Instance.SavePREFS();
        }
        SceneManager.LoadScene(_sID);
        Time.timeScale = 1;
    }

    public void TM()
    {
        if (_iWPA)
        {
            MoneyManager.Instance.SavePREFS();
        }
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
