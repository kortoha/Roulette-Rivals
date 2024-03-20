using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public TextMeshProUGUI openPriceText;
    public GameObject priceImage;
    public int openPrice = 300;

    public Sprite _levelOpenImage;
    public Sprite _levelCloseImage;

    [SerializeField] private int _sceneID;
    [SerializeField] private bool _isOpened = false;

    private Button _levelButton;
    private Image _levelImage;

    [NonSerialized] public int buttonID;

    private void Start()
    {
        _levelButton = GetComponent<Button>();
        _levelImage = GetComponent<Image>();

        openPriceText.text = openPrice.ToString();

        _levelButton.onClick.AddListener(BuyOrPlay);
    }

    private void Update()
    {
        UpdateButtonVisual();
    }

    public void UpdateButtonVisual()
    {
        switch (_isOpened)
        {
            case true:
                _levelImage.sprite = _levelOpenImage;
                priceImage.SetActive(false);
                break;
            case false:
                _levelImage.sprite = _levelCloseImage;
                priceImage.SetActive(true);
                break;
        }
    }

    private void BuyOrPlay()
    {
        switch (_isOpened)
        {
            case true:
                ClickSound.Instance.PlayCoin();
                SceneManager.LoadScene(_sceneID);
                break;
            case false:
                if (openPrice <= MoneyManager.Instance.GC())
                {
                    ClickSound.Instance.PlayCoin();
                    CoinSound.Instance.PlayCoin();
                    MoneyManager.Instance.BFM(openPrice);
                    MoneyManager.Instance.SPREFS();
                    LevelManager.Instance.SLES(buttonID, true);
                    _isOpened = true;

                }
                break;
        }
    }

    public bool IsOpen()
    {
        return _isOpened;
    }

    public void SetState(bool state)
    {
        _isOpened = state;
    }
}
