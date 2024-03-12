using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreeSpin : MonoBehaviour
{
    public Button _freeSpinButton;
    public SpinEnergy _spinEnergy;
    public Transform freeSpinFX;
    public Transform tablePanelParent;

    private bool _isOnce = false;

    private void OnEnable()
    {
        _freeSpinButton.onClick.AddListener(() =>
        {
            AddFreeSpin();
        });
    }

    private void AddFreeSpin()
    {
        if (!_isOnce)
        {
            _isOnce = true;
            _spinEnergy.BuyGoldChip();
            Transform fx = Instantiate(freeSpinFX, Vector2.zero, Quaternion.identity);
            fx.SetParent(tablePanelParent);
            StartCoroutine(DFX(fx));
            SFXManager.Instance.PlaySound(SFXManager.Instance.freeSpin);
        }
        else
        {
            _spinEnergy.BuyGoldChip();
        }
    }

    private IEnumerator DFX(Transform fx)
    {
        yield return new WaitForSeconds(1);
        Destroy(fx.gameObject);
        _isOnce = false;
    }
}
