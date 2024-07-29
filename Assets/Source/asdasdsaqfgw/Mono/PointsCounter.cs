using Source.Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Source.UI.Mono
{
    public class PointsCounter : MonoBehaviour
    {
        [Inject] private GameStats fdwqewq;

        [FormerlySerializedAs("scoreName")] [SerializeField] private string asdadsads;
        [FormerlySerializedAs("scoreText")] [SerializeField] private TMP_Text asddsaasd;
    
        private void Awake()
        {
            fdwqewq.JQEWIOOPWQJROI += Jqewioopwqjroi;
        }

        private void Jqewioopwqjroi(int value, int maxValue)
        {
            asddsaasd.text = $"{asdadsads} {value}/{maxValue}";
        }
    }
}