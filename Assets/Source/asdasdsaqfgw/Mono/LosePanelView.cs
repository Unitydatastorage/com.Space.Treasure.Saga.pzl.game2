using Source.Game;
using UnityEngine;
using VContainer;

namespace Source.UI.Mono
{
    public class LosePanelView : UIView
    {
        [Inject] private GameStats dasdasdqwe;

        private void Awake()
        {
            dasdasdqwe.ASOPSDKOPOASKD += ShowOnLose;
            dasdasdqwe.ewioeqop += Hide;
            Hide();
        }

        private void ShowOnLose()
        {
            Show();
        }

        public void Restart()
        {
            dasdasdqwe.Restart();
        }

        public void StopGame()
        {
            dasdasdqwe.Menu();
            Hide();
        }
    }
}