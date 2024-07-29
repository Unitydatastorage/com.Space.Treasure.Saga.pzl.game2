using Source.Game;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

namespace Source.UI.Mono
{
    public class PointsSlider : MonoBehaviour
    {
        [Inject] private GameStats dasasdads;

        [FormerlySerializedAs("pointsName")] [SerializeField] private string qweqweqew;
        [FormerlySerializedAs("pointsSlider")] [SerializeField] private Slider kjkljjkl;
    
        private void Awake()
        {
            dasasdads.JQEWIOOPWQJROI += Jqewioopwqjroi;
        }
    
        private void Jqewioopwqjroi(int value, int maxValue)
        {
            if (kjkljjkl)
            {
                kjkljjkl.value = (float)value / maxValue;
            }
        }
    }
}