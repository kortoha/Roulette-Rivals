using System;
using TMPro;
using UnityEngine;

public class MiniGameInput : MonoBehaviour
{
    public static MiniGameInput Instance { get; private set; }

    [NonSerialized] public bool iW = false;

    GoldChip _gC;

    [SerializeField] GameObject _fWP;
    [SerializeField] GameObject _tTB;
    [SerializeField] TextMeshProUGUI _tT;

    float _t = 15;
    float _cT;

    void OnEnable()
    {
        Instance = this;
        iW = false;
    }

    void Update()
    {
        I();
        RGC();
        _tT.enabled = IHC();

        _tT.text = Mathf.FloorToInt(_cT).ToString();
        WM();

        if(IHC() && !iW && _cT <= 0)
        {
            iW = true;
            _gC.WE();
            IW();
        }
    }

    bool IHC()
    {
        if (_gC != null)
        {
            return true;
        }
        return false;
    }

    void I()
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
                if (h.collider.gameObject.layer == LayerMask.NameToLayer("GoldChip"))
                {
                    _gC = h.collider.gameObject.GetComponent<GoldChip>();
                    _gC.iP = true;
                }
            }
        }
    }

    void WM()
    {
        if (IHC())
        {
            _cT -= Time.deltaTime;

            if(_cT <= 0)
            {
                _cT = 0;
            }
        }
        else
        {
            _cT = _t;
        }
    }

    void RGC()
    {
        if (_gC != null && Input.GetMouseButton(0))
        {
            Vector3 nP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nP.z = 0f;
            _gC.transform.position = nP;
        }

        if (_gC != null && Input.GetMouseButtonUp(0))
        {
            _gC.iP = false;
            _gC = null;
        }
    }

    void W()
    {
        SpinEnergy.Instance.iMO = false;
        _gC = null;
        Fader.Instance.PFA();
        Invoke("IO", 0.51f);
    }

    void IW()
    {
        Invoke("W", 0.5f);
    }

    void IO()
    {
        _fWP.SetActive(true);
        _tTB.SetActive(true);
        gameObject.SetActive(false);
    }
}
