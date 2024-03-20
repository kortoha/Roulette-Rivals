using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    [SerializeField] private int _bCC;
    [SerializeField] private int _pCC;
    [SerializeField] private int _rCC;
    [SerializeField] private int _cC = 300;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        LPREFS();
    }

    public void TBC(int cC)
    {
        _bCC += cC;
    }
    public void TRC(int cC)
    {
        _rCC += cC;
    }
    public void TPC(int cC)
    {
        _pCC += cC;
    }

    public int GPC()
    {
        return _pCC;
    }
    public int GRC()
    {
        return _rCC;
    }
    public int GBC()
    {
        return _bCC;
    }

    public int GC()
    {
        return _cC;
    }

    public void BFBC(int p)
    {
        _bCC -= p;
    }
    public void BFRC(int p)
    {
        _rCC -= p;
    }
    public void BFPC(int p)
    {
        _pCC -= p;
    }

    public void WBC(int a)
    {
        _bCC += a;
    }
    public void WRC(int p)
    {
        _rCC += p;
    }
    public void WPC(int a)
    {
        _pCC += a;
    }

    public void WM(int a)
    {
        _cC += a;
    }

    public void BFM(int a)
    {
        _cC -= a;
    }

    public void LPREFS()
    {
        _bCC = PlayerPrefs.GetInt("BlueChip", 0);
        _pCC = PlayerPrefs.GetInt("PinkChip", 0);
        _rCC = PlayerPrefs.GetInt("RedChip", 0);
        _cC = PlayerPrefs.GetInt("MoneyScore", 300);
    }

    public void SPREFS()
    {
        PlayerPrefs.SetInt("BlueChip", _bCC);
        PlayerPrefs.SetInt("PinkChip", _pCC);
        PlayerPrefs.SetInt("RedChip", _rCC);
        PlayerPrefs.SetInt("MoneyScore", _cC);
        PlayerPrefs.Save();
    }
}
