using System;
using TMPro;
using UnityEngine;

public class GoldChip : MonoBehaviour
{
    [NonSerialized] int wECC = 1;
    [NonSerialized] public bool iP = false;

    [SerializeField] GameObject _fX;
    [SerializeField] GameObject _pFX;
    [SerializeField] TextMeshProUGUI _eCT;
    Rigidbody2D cRB;


    private void OnEnable()
    {
        _eCT.enabled = false;
        cRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Braker"))
        {
            GameObject fx = Instantiate(_fX, transform.position, Quaternion.identity);
            MGFXD.Instance.ATFXA(fx);
            fx.transform.SetParent(MGFXD.Instance.transform);
            Destroy(gameObject);
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("GoldChip"))
        {
            GameObject fx = Instantiate(_pFX, transform.position, Quaternion.identity);
            MGFXD.Instance.ATFXA(fx);
            fx.transform.SetParent(MGFXD.Instance.transform);
            Destroy(c.gameObject);
            wECC++;
        }
    }

    private void Update()
    {
        _eCT.text = wECC.ToString();

        if (iP)
        {
            gameObject.layer = LayerMask.NameToLayer("n");
            _eCT.enabled = true;
            cRB.gravityScale = 0;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("GoldChip");
            _eCT.enabled = false;
            cRB.gravityScale = 0.8f;
        }

        if (MiniGameInput.Instance.iW)
        {
            Destroy(gameObject);
        }
    }

    public void WE()
    {
        SpinEnergy.Instance.WGC(wECC);
    }
}
