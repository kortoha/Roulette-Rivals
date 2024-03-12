using System;
using UnityEngine;

public class WheelIndicator : MonoBehaviour
{
    public static WheelIndicator Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private WheelItem _wheelItem;

    [NonSerialized] public bool isWinOnse = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (!FortuneWheel.Instance.isSF && FortuneWheel.Instance.ICS() && !isWinOnse)
            {
                _wheelItem = collision.gameObject.GetComponent<WheelItem>();
                _wheelItem.WinChips();
                isWinOnse = true;
            }
        }
    }
}
