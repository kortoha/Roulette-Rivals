using System;
using System.Collections.Generic;
using UnityEngine;

public class MGFXD : MonoBehaviour
{
    public static MGFXD Instance { get; private set; }

    public List<GameObject> _fxL;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach (var item in _fxL)
        {
            if (item != null)
            {
                objectsToRemove.Add(item);
            }
        }

        foreach (var item in objectsToRemove)
        {
            _fxL.Remove(item);
            DestroyImmediate(item);
        }
    }

    public void ATFXA(GameObject fx)
    {
        _fxL.Add(fx);
    }
}
