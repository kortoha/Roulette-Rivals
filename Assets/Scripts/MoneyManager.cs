using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    [SerializeField] private int _blueChipCount;
    [SerializeField] private int _pinkChipCount;
    [SerializeField] private int _redChipCount;
    [SerializeField] private int _coinCount = 300;

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
        LoadPREFS();
    }

    public void TakeBlueChips(int chipCount)
    {
        _blueChipCount += chipCount;
    }
    public void TakeRedChips(int chipCount)
    {
        _redChipCount += chipCount;
    }
    public void TakePinkChips(int chipCount)
    {
        _pinkChipCount += chipCount;
    }

    public int GetPinkChips()
    {
        return _pinkChipCount;
    }
    public int GetRedChips()
    {
        return _redChipCount;
    }
    public int GetBlueChips()
    {
        return _blueChipCount;
    }

    public int GetCoins()
    {
        return _coinCount;
    }

    public void BuyForBlueChips(int price)
    {
        _blueChipCount -= price;
    }
    public void BuyForRedChips(int price)
    {
        _redChipCount -= price;
    }
    public void BuyForPinkChips(int price)
    {
        _pinkChipCount -= price;
    }

    public void WinBlueChips(int amount)
    {
        _blueChipCount += amount;
    }
    public void WinRedChips(int price)
    {
        _redChipCount += price;
    }
    public void WinPinkChips(int amount)
    {
        _pinkChipCount += amount;
    }

    public void WinMoney(int amount)
    {
        _coinCount += amount;
    }

    public void BuyForMoney(int amount)
    {
        _coinCount -= amount;
    }

    public void LoadPREFS()
    {
        _blueChipCount = PlayerPrefs.GetInt("BlueChip", 0);
        _pinkChipCount = PlayerPrefs.GetInt("PinkChip", 0);
        _redChipCount = PlayerPrefs.GetInt("RedChip", 0);
        _coinCount = PlayerPrefs.GetInt("MoneyScore", 300);
    }

    public void SavePREFS()
    {
        PlayerPrefs.SetInt("BlueChip", _blueChipCount);
        PlayerPrefs.SetInt("PinkChip", _pinkChipCount);
        PlayerPrefs.SetInt("RedChip", _redChipCount);
        PlayerPrefs.SetInt("MoneyScore", _coinCount);
        PlayerPrefs.Save();
    }
}
