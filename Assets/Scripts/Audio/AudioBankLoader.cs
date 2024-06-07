using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBankLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
