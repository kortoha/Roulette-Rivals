using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public bool isCanOpen = false;
    [NonSerialized] public int losedMoney;

    [SerializeField] private TipeOfCellPrice _tipe;
    [SerializeField] private Image _tipeOfChipPrice;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private int _price;

    [SerializeField] private Sprite _blueChipSprite;
    [SerializeField] private Sprite _pinkChipSprite;
    [SerializeField] private Sprite _redChipSprite;
    [SerializeField] private SpriteRenderer _lockSprite;

    [SerializeField] private GameObject _2xIcon;
    [SerializeField] private GameObject _voidIcon;
    [SerializeField] private GameObject _winMoneyIcon;

    [SerializeField] private Transform _2xFX;
    [SerializeField] private Transform _vFX;
    [SerializeField] private Transform _cFX;

    [SerializeField] private Transform _tPP;

    private Sprite _currentSprite;
    private bool _isOpen = false;
    private bool _isReturnedChips = false;

    private TipeOfCell _tipeOfCell;

    private void Awake()
    {      
        _tipeOfCell = (TipeOfCell)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TipeOfCell)).Length);
    }

    public enum TipeOfCellPrice
    {
        BluePrice,
        PinkPrice,
        RedPrice
    }

    public enum TipeOfCell
    {
        TwoX,
        Void,
        WinMoney
    }

    private void OnEnable()
    {
        switch (_tipe)
        {
            case TipeOfCellPrice.BluePrice:
                _currentSprite = _blueChipSprite;
                break;
            case TipeOfCellPrice.PinkPrice:
                _currentSprite = _pinkChipSprite;
                break;
            case TipeOfCellPrice.RedPrice:
                _currentSprite = _redChipSprite;
                break;
        }
        _priceText.text = _price.ToString();
        _tipeOfChipPrice.sprite = _currentSprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TryOpenCell(collision);
    }

    private void TryOpenCell(Collider2D collider)
    {
        if(isCanOpen && !_isOpen)
        {    
            switch (_tipe)
            {
                case TipeOfCellPrice.BluePrice:
                    if(MoneyManager.Instance.GBC() >= _price && collider.gameObject.layer == LayerMask.NameToLayer("BlueChip"))
                    {
                        _lockSprite.enabled = false;
                        OpenCell("BlueChip", collider);
                        MoneyManager.Instance.BFBC(_price);
                    }
                    break;
                case TipeOfCellPrice.PinkPrice:
                    if (MoneyManager.Instance.GPC() >= _price && collider.gameObject.layer == LayerMask.NameToLayer("PinkChip"))
                    {
                        _lockSprite.enabled = false;
                        OpenCell("PinkChip", collider);
                        MoneyManager.Instance.BFPC(_price);
                    }
                    break;
                case TipeOfCellPrice.RedPrice:
                    if (MoneyManager.Instance.GRC() >= _price && collider.gameObject.layer == LayerMask.NameToLayer("RedChip"))
                    {
                        _lockSprite.enabled = false;
                        OpenCell("RedChip", collider);
                        MoneyManager.Instance.BFRC(_price);
                    }
                    break;
            }
        }
    }

    private void OpenCell(string layerName, Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
            _isOpen = true;
            _priceText.enabled = false;
            _tipeOfChipPrice.enabled = false;
            WinSTMTNG();
        }
    }

    public void ReturnLoseMoney()
    {
        if (_isOpen && !_isReturnedChips)
        {
            switch (_tipe)
            {
                case TipeOfCellPrice.BluePrice:
                    MoneyManager.Instance.WBC(losedMoney);
                    break;
                case TipeOfCellPrice.PinkPrice:
                    MoneyManager.Instance.WPC(losedMoney);
                    break;
                case TipeOfCellPrice.RedPrice:
                    MoneyManager.Instance.WRC(losedMoney);
                    break;
            }
            _isReturnedChips = true;
        }
    }

    private void WinSTMTNG()
    {
        switch (_tipeOfCell)
        {
            case TipeOfCell.TwoX:
            int newPrice = _price * 2;
                SFXManager.Instance.PlaySound(SFXManager.Instance.twoX);
                switch (_tipe)
                {
                    case TipeOfCellPrice.BluePrice:
                        MoneyManager.Instance.WBC(newPrice);
                        break;
                    case TipeOfCellPrice.PinkPrice:
                        MoneyManager.Instance.WPC(newPrice);
                        break;
                    case TipeOfCellPrice.RedPrice:
                        MoneyManager.Instance.WRC(newPrice);
                        break;
                }
                _2xIcon.SetActive(true);
                Transform fx = Instantiate(_2xFX, Vector2.zero, Quaternion.identity);
                fx.SetParent(_tPP);

                StartCoroutine(DFX(fx));
                break;
            case TipeOfCell.Void:
                SFXManager.Instance.PlaySound(SFXManager.Instance._void);
                losedMoney = _price;
                _voidIcon.SetActive(true);
                Transform vfx = Instantiate(_vFX, Vector2.zero, Quaternion.identity);
                vfx.SetParent(_tPP);

                StartCoroutine(DFX(vfx));
                break;
            case TipeOfCell.WinMoney:
                SFXManager.Instance.PlaySound(SFXManager.Instance.winMoney);
                SFXManager.Instance.PlaySound(SFXManager.Instance.moneySFX);
                int money = UnityEngine.Random.Range(50, 200);
                MoneyManager.Instance.WM(money);
                _winMoneyIcon.SetActive(true);

                Transform cfx = Instantiate(_cFX, Vector2.zero, Quaternion.identity);
                cfx.SetParent(_tPP);

                StartCoroutine(DFX(cfx));
                break;
            default:
                break;
        }
    }

    private IEnumerator DFX(Transform fx)
    {
        yield return new WaitForSeconds(1);
        Destroy(fx.gameObject);
    }

    public bool IsOpen()
    {
        return _isOpen;
    }
}
