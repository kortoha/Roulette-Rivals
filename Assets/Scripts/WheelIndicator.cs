using System;
using UnityEngine;

public class WheelIndicator : MonoBehaviour
{
    public static WheelIndicator Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private WheelItem _wI;

    [NonSerialized] public bool iWO = false;

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (!FortuneWheel.Instance.isSF && FortuneWheel.Instance.ICS() && !iWO)
            {
                _wI = c.gameObject.GetComponent<WheelItem>();
                _wI.WC();
                iWO = true;
            }
        }
    }
}
