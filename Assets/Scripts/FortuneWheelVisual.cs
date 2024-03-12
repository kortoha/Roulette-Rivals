using TMPro;
using UnityEngine;

public class FortuneWheelVisual : MonoBehaviour
{
    public TextMeshProUGUI blueChipCountText;
    public TextMeshProUGUI redChipCountText;
    public TextMeshProUGUI pinkChipCountText;


    private void Update()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        blueChipCountText.text = MoneyManager.Instance.GetBlueChips().ToString();
        redChipCountText.text = MoneyManager.Instance.GetRedChips().ToString();
        pinkChipCountText.text = MoneyManager.Instance.GetPinkChips().ToString();
    }
}
