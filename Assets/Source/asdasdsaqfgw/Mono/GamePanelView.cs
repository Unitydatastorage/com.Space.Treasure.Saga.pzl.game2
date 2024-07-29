using System;
using Source.Game;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using VContainer;

namespace Source.UI.Mono
{
    public class GamePanelView : UIView
    {
        [Inject] private GameStats n_gameStats;

        private void Awake()
        {
            n_gameStats.ewioeqop += Show;
            n_gameStats.QWIOEIJORIOJERWT += OnNGameStop;
            n_gameStats.ASOPSDKOPOASKD += OnNGameStop;
            n_gameStats.OIQWEQOWPRQWE += OnNGameStop;
            Hide();
        }

        private void OnNGameStop()
        {
            Hide();
        }

        public void RestartLevel()
        {
            n_gameStats.Restart();
        }

        public void PauseLevel()
        {
            n_gameStats.Pause();
        }

        public void BackMenu()
        {
            n_gameStats.Menu();
        }
    }
}