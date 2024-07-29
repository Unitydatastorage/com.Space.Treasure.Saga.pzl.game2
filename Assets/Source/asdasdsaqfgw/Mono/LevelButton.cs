using System;
using Source.Game;
using Source.Level.Mono;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.UI.Mono
{
    public class LevelButton : MonoBehaviour
    {
        [FormerlySerializedAs("_startLevelButton")] [SerializeField] private Button adsfdfassdfg;
        [FormerlySerializedAs("_levelNameText")] [SerializeField] private TMP_Text asdsaasd;
        [FormerlySerializedAs("_levelPrefix")] [SerializeField] private string fdsadsf123;
        private GameStats _gameStats;

        private int _index = 0;

        private void Awake()
        {
            if (adsfdfassdfg == null)
            {
                adsfdfassdfg = GetComponent<Button>();
            }
        }

        public void Init(GameStats gameStats, int index)
        {
            _gameStats = gameStats;
            _index = index;
            UpdateUI();
            _gameStats.OIQWEQOWPRQWE += CheckOpen;
            CheckOpen();
            adsfdfassdfg.onClick.AddListener(StartLevel);
        }

        private void UpdateUI()
        {
            asdsaasd.text = $"{fdsadsf123}{_index + 1}";
        }

        private void CheckOpen()
        {
            if (_index != 0)
            {
                adsfdfassdfg.interactable = PlayerPrefs.GetInt("Level_" + _index, 0) == 1;
            }
        }

        private void StartLevel()
        {
            _gameStats.StartLevel(_index);
        }
    }
}