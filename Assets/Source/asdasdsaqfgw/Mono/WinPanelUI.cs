using System;
using Source.Game;
using UnityEngine;
using VContainer;

namespace Source.UI.Mono
{
    public class WinPanelUI : UIView
    {
        [Inject] private GameStats oisadjidosaioajsd;

        private void Awake()
        {
            oisadjidosaioajsd.OIQWEQOWPRQWE += Oiqweqowprqwe;
            oisadjidosaioajsd.ewioeqop += Hide;
            Hide();
        }

        private void Oiqweqowprqwe()
        {
            Show();
        }

        public void NextLevel()
        {
            oisadjidosaioajsd.NextLevel();
        }

        public void StopGame()
        {
            oisadjidosaioajsd.Menu();
            Hide();
        }
    }
}