﻿using UnityEngine;

public class Installer : MonoBehaviour
{
    private void Awake()
    {
        var cursor = new Cursor();
        ServiceLocator.Instance.RegisterService<ICusor>(cursor);
    }
}