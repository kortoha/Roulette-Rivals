using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField] private Button _bCB; 
    [SerializeField] private Button _pCB; 
    [SerializeField] private Button _rCB;

    [SerializeField] private TextMeshProUGUI _bCC; 
    [SerializeField] private TextMeshProUGUI _pCC; 
    [SerializeField] private TextMeshProUGUI _rCC; 
    [SerializeField] private TextMeshProUGUI _cC; 

    private int _bP = 5; 
    private int _pP = 10; 
    private int _rP = 15; 

    private void Update()
    {
        UV(); 
    }

    private void Start()
    {
        _bCB.onClick.AddListener(ECB); 
        _pCB.onClick.AddListener(EPCB); 
        _rCB.onClick.AddListener(ERC); 
    }

    private void ECB() 
    {
        if(MoneyManager.Instance.GBC() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BFBC(1);
            MoneyManager.Instance.WM(_bP); 
            MoneyManager.Instance.SPREFS();
        }
    }

    private void EPCB()
    {
        if (MoneyManager.Instance.GPC() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BFPC(1); 
            MoneyManager.Instance.WM(_pP);
            MoneyManager.Instance.SPREFS();
        }
    }

    private void ERC() 
    {
        if (MoneyManager.Instance.GRC() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BFRC(1); 
            MoneyManager.Instance.WM(_rP);
            MoneyManager.Instance.SPREFS();
        }
    }

    private void UV() 
    {
        _bCC.text = MoneyManager.Instance.GBC().ToString(); 
        _pCC.text = MoneyManager.Instance.GPC().ToString(); 
        _rCC.text = MoneyManager.Instance.GRC().ToString(); 
        _cC.text = MoneyManager.Instance.GC().ToString(); 
    }
}
