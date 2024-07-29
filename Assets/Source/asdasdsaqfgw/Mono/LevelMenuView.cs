using System;
using Source.Game;
using Source.Level.Mono;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Serialization;
using VContainer;

namespace Source.UI.Mono
{
    public class LevelMenuView : UIView
    {
        [FormerlySerializedAs("_levelPanel")] [SerializeField] private Transform dsadas213;
        [FormerlySerializedAs("_levelButtonPrefab")] [SerializeField] private LevelButton asfdsadfqwe;

        [Inject] private GameSettingsScriptable saddasdsaasdf;
        [Inject] private GameStats asdasddasfqwqew;

        private void Awake()
        {
            InitializeLevelButtons();
            asdasddasfqwqew.ewioeqop += Hide;
        }

        private void InitializeLevelButtons()
        {
            for (int index = 0; index < saddasdsaasdf.LevelScriptables.Length; index++)
            {
                LevelButton newLevelButton = Instantiate(asfdsadfqwe, dsadas213);
                newLevelButton.Init(asdasddasfqwqew, index);
            }
        }
    }
}