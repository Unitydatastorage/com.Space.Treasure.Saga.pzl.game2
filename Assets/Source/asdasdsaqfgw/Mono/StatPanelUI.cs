using Source.Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

namespace Source.UI.Mono
{
    public class StatPanelUI : MonoBehaviour
    {
        [Inject] private GameStats deqwqeweqw;
    
        [FormerlySerializedAs("timerText")] [SerializeField] private TMP_Text fdsqeweqw;
        [FormerlySerializedAs("levelName")] [SerializeField] private TMP_Text fasdodfspokdsf;
        [FormerlySerializedAs("timerSlider")] [SerializeField] private Slider asdoijdasijoasd;

        private void Awake()
        {
            deqwqeweqw.URIUIEWWREKLMSDF += Uriuiewwreklmsdf;
            deqwqeweqw.JIQEWOQRDFSLS += Jiqewoqrdfsls;
        }

        private void Jiqewoqrdfsls(int level)
        {
            if (fasdodfspokdsf)
            {
                fasdodfspokdsf.text = $"Level: {level}";
            }
        }

        private void Uriuiewwreklmsdf(float time)
        {
            UpdateTimerText(time);
            UpdateTimerSlider(time);
        }

        private void UpdateTimerText(float time)
        {
            if (fdsqeweqw)
            {
                int minutes = Mathf.FloorToInt(time / 60f);
                int seconds = Mathf.RoundToInt(time % 60f);
                fdsqeweqw.text = $"Timer: {minutes}m.{seconds}s.";
            }
        }

        private void UpdateTimerSlider(float time)
        {
            if (asdoijdasijoasd)
            {
                float sliderValue = time / deqwqeweqw.LevelTime;
                asdoijdasijoasd.value = Mathf.Clamp01(sliderValue);
            }
        }
    }
}