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
        if(MoneyManager.Instance.GetBlueChips() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BuyForBlueChips(1);
            MoneyManager.Instance.WinMoney(_bP); 
            MoneyManager.Instance.SavePREFS();
        }
    }

    private void EPCB()
    {
        if (MoneyManager.Instance.GetPinkChips() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BuyForPinkChips(1); 
            MoneyManager.Instance.WinMoney(_pP);
            MoneyManager.Instance.SavePREFS();
        }
    }

    private void ERC() 
    {
        if (MoneyManager.Instance.GetRedChips() >= 1)
        {
            ClickSound.Instance.PlayCoin();
            CoinSound.Instance.PlayCoin();
            MoneyManager.Instance.BuyForRedChips(1); 
            MoneyManager.Instance.WinMoney(_rP);
            MoneyManager.Instance.SavePREFS();
        }
    }

    private void UV() 
    {
        _bCC.text = MoneyManager.Instance.GetBlueChips().ToString(); 
        _pCC.text = MoneyManager.Instance.GetPinkChips().ToString(); 
        _rCC.text = MoneyManager.Instance.GetRedChips().ToString(); 
        _cC.text = MoneyManager.Instance.GetCoins().ToString(); 
    }
}
