using System;
using Source.Game;
using UnityEngine;
using VContainer;

namespace Source.UI.Mono
{
    public class PausePanelView : UIView
    {
        [Inject] private GameStats dsadsaads;

        private void Awake()
        {
            dsadsaads.QWIOEIJORIOJERWT += Hide;
            Hide();
        }

        public void Resume()
        {
            dsadsaads.Resume();
        }

        public void StopGame()
        {
            dsadsaads.Menu();
        }
    }
}