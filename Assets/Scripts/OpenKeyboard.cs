using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    public void ShowKeyboard()
    {
        Debug.Log("Opening Keyboard");
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
