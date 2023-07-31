using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Common;
using TMPro;
public class GameOverUI :MenuWindow {
    [SerializeField] TMP_Text TMProText;
    
    public void SetGameOverText(string text) => TMProText.text = text.ToString();
}
