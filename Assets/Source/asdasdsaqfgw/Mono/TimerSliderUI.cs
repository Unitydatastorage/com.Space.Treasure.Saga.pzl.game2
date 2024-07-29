using System;
using Source.Game;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

namespace Source.UI.Mono
{
    public class TimerSliderUI : MonoBehaviour
    {
        [Inject] private GameStats oidjasadijo;

        [FormerlySerializedAs("timerName")] [SerializeField] private string jiadiojsda;
        [FormerlySerializedAs("timerSlider")] [SerializeField] private Slider jasjasdioj;

        [FormerlySerializedAs("gameSettingsScriptable")] [SerializeField] private GameSettingsScriptable asdjiiojasd;
    
        private void Awake()
        {
            oidjasadijo.URIUIEWWREKLMSDF += Uriuiewwreklmsdf;
            oidjasadijo.ewioeqop += Ewioeqop;
        }

        private void Ewioeqop()
        {
            gameObject.SetActive(asdjiiojasd.TimerEnable);
        }

        private void Uriuiewwreklmsdf(float time)
        {
            if (jasjasdioj)
            {
                jasjasdioj.value = time / oidjasadijo.LevelTime;
            }
        }
    }
}