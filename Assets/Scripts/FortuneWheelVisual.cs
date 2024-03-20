using TMPro;
using UnityEngine;

public class FortuneWheelVisual : MonoBehaviour
{
    public TextMeshProUGUI bCCT;
    public TextMeshProUGUI rCCT;
    public TextMeshProUGUI pCCT;


    private void Update()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        bCCT.text = MoneyManager.Instance.GBC().ToString();
        rCCT.text = MoneyManager.Instance.GRC().ToString();
        pCCT.text = MoneyManager.Instance.GPC().ToString();
    }
}
