using Source.Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Source.UI.Mono
{
    public class LevelName : MonoBehaviour
    {
        [Inject] private GameStats dasadsdasqw;

        [FormerlySerializedAs("_levelText")] [SerializeField] private string qwewqwqesda;
        [FormerlySerializedAs("_levelName")] [SerializeField] private TMP_Text saddasdasqw;

        private void Awake()
        {
            UpdateLevelName(dasadsdasqw.Sdaioojdasi + 1);
            dasadsdasqw.JIQEWOQRDFSLS += UpdateLevelName;
        }

        private void UpdateLevelName(int val)
        {
            if (saddasdasqw != null)
            {
                saddasdasqw.text = $"{qwewqwqesda} {val}";
            }
        }
    }
}