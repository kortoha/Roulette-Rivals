using TMPro;
using UnityEngine;

public class TableGame : MonoBehaviour
{
    public static TableGame Instance { get; private set; }

    [SerializeField] private Transform _bC; 
    [SerializeField] private Transform _pC; 
    [SerializeField] private Transform _rC; 
    [SerializeField] private Cell[] _cA; 

    [SerializeField] private TextMeshProUGUI _bCText; 
    [SerializeField] private TextMeshProUGUI _pCText; 
    [SerializeField] private TextMeshProUGUI _rCText;
    [SerializeField] private TextMeshProUGUI _cCText;

    private bool _iCT = false;

    private Transform _cC;
    private SpriteRenderer _cCR;
    private CircleCollider2D _sC2D;

    private void Update()
    {
        _bCText.text = MoneyManager.Instance.GetBlueChips().ToString();
        _pCText.text = MoneyManager.Instance.GetPinkChips().ToString();
        _rCText.text = MoneyManager.Instance.GetRedChips().ToString();
        _cCText.text = MoneyManager.Instance.GetCoins().ToString();

        IM();
        MCI();
    }

    private void IM()
    {
        bool mBD = Input.GetMouseButtonDown(0);
        bool iTD = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;

        if (mBD || iTD)
        {
            Vector3 iP = mBD ? Camera.main.ScreenToWorldPoint(Input.mousePosition) :
                Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            RaycastHit2D h = Physics2D.Raycast(iP, Vector2.zero);

            if (h.collider != null)
            {
                if (h.collider.gameObject.layer == LayerMask.NameToLayer("BlueChip"))
                {
                    if (!_iCT)
                    {
                        _cC = Instantiate(_bC, iP, Quaternion.identity);
                        _iCT = true;
                    }
                }
                else if (h.collider.gameObject.layer == LayerMask.NameToLayer("PinkChip"))
                {
                    if (!_iCT)
                    {
                        _cC = Instantiate(_pC, iP, Quaternion.identity);
                        _iCT = true;
                    }
                }
                else if (h.collider.gameObject.layer == LayerMask.NameToLayer("RedChip"))
                {
                    if (!_iCT)
                    {
                        _cC = Instantiate(_rC, iP, Quaternion.identity);
                        _iCT = true;
                    }
                }
            }
        }
        else
        {
            _iCT = false;
        }
    }

    private void MCI()
    {
        if (_cC != null && (_iCT || Input.GetMouseButton(0)))
        {
            Vector3 nP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nP.z = 0f;
            _cC.position = nP;
            foreach (var i in _cA)
            {
                i.isCanOpen = false;
            }
        }

        if (_cC != null && (!_iCT && Input.GetMouseButtonUp(0)))
        {
            _cCR = _cC.GetComponent<SpriteRenderer>();
            _sC2D = _cC.GetComponent<CircleCollider2D>();
            _sC2D.enabled = true;
            _cCR.enabled = false;
            Invoke("DC", 1);
            foreach (var i in _cA)
            {
                i.isCanOpen = true;
            }
        }
    }

    private void DC()
    {
        if (_cC != null)
        {
            Destroy(_cC.gameObject);
            _cC = null;
        }
    }
}
