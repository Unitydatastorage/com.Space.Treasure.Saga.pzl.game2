using System;
using Source.Game;
using UnityEngine;
using VContainer;

namespace Source.UI.Mono
{
    public class MainMenuView : PoliceConfirmView
    {
        [Inject] private GameStats asddasasdqwe;

        private void Awake()
        {
            asddasasdqwe.QWIOEIJORIOJERWT += Show;
            Hide();
        }
    }
}