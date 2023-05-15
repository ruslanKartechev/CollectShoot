using System;
using GameCore.GameUI.Buttons;
using TMPro;
using UnityEngine;

namespace GameCore.GameUI.Pages
{
    public class UIPageWithButton : UIPage
    {
        [SerializeField] protected TextMeshProUGUI _btnText;
        [SerializeField] protected ProperButton _button;
    }
}