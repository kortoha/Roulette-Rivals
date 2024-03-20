using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _sp; 
    [SerializeField] private GameObject _lp; 
    [SerializeField] private GameObject _tp; 
    [SerializeField] private GameObject _bp; 

    [Header("Levels&&TutorPages")]
    [SerializeField] private GameObject[] _lP; 
    [SerializeField] private GameObject[] _tP; 

    public Button sb; 

    public Sprite soS; 
    public Sprite sfS; 

    private int _cli = 0; 
    private int _ctp = 0; 
    private bool _iso;

    private void Start()
    {
        _iso = PlayerPrefs.GetInt("IsSoundOn", 0) == 0;
        AudioListener.pause = _iso;
        sb.onClick.AddListener(TS);

        USBS();
    }

    private void TS() 
    {
        ClickSound.Instance.PlayCoin();
        _iso = !_iso;

        PlayerPrefs.SetInt("IsSoundOn", _iso ? 0 : 1);
        AudioListener.pause = _iso;
        USBS();
    }

    private void USBS() 
    {
        sb.image.sprite = _iso ? sfS : soS;
    }

    public void OLP() 
    {
        ClickSound.Instance.PlayCoin();
        _sp.SetActive(false);
        _lp.SetActive(true);
    }

    public void OTP() 
    {
        ClickSound.Instance.PlayCoin();
        _tp.SetActive(true);
        _sp.SetActive(false);
    }

    public void OBP() 
    {
        ClickSound.Instance.PlayCoin();
        _bp.SetActive(true);
        _sp.SetActive(false);
    }

    public void CBP() 
    {
        ClickSound.Instance.PlayCoin();
        _bp.SetActive(false);
        _sp.SetActive(true);
    }

    public void CTP() 
    {
        ClickSound.Instance.PlayCoin();
        _tp.SetActive(false);
        _sp.SetActive(true);
    }

    public void CLP() 
    {
        ClickSound.Instance.PlayCoin();
        _lp.SetActive(false);
        _sp.SetActive(true);
    }

    public void TNP() 
    {
        ClickSound.Instance.PlayCoin();
        if (_ctp < _tP.Length - 1)
        {
            _tP[_ctp].SetActive(false);
            _ctp++;
            _tP[_ctp].SetActive(true);
        }
    }

    public void TPP() 
    {
        ClickSound.Instance.PlayCoin();
        if (_ctp > 0)
        {
            _tP[_ctp].SetActive(false);
            _ctp--;
            _tP[_ctp].SetActive(true);
        }
    }

    public void LNP() 
    {
        ClickSound.Instance.PlayCoin();
        if (_cli < _lP.Length - 1)
        {
            _lP[_cli].SetActive(false);
            _cli++;
            _lP[_cli].SetActive(true);
        }
    }

    public void LPP() 
    {
        ClickSound.Instance.PlayCoin();
        if (_cli > 0)
        {
            _lP[_cli].SetActive(false);
            _cli--;
            _lP[_cli].SetActive(true);
        }
    }
}
