using Source.Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

namespace Source.UI.Mono
{
    public enum TimerType
    {
        MinSec,
        Sec,
    }

    public class TimerPanelUI : MonoBehaviour
    {
        [Inject] private GameStats idasjiasdo;

        [FormerlySerializedAs("timerName")] [SerializeField] private string asidiojasd;
        [FormerlySerializedAs("timerText")] [SerializeField] private TMP_Text jsadjoasd;
        [FormerlySerializedAs("timerType")] [SerializeField] private TimerType jadsjasdkjl;

        private void Awake()
        {
            idasjiasdo.URIUIEWWREKLMSDF += Uriuiewwreklmsdf;
        }
    
        private void Uriuiewwreklmsdf(float time)
        {
            if (jsadjoasd)
            {
                switch (jadsjasdkjl)
                {
                    case TimerType.MinSec:
                        UpdateMinSecTimer(time);
                        break;
                    case TimerType.Sec:
                        UpdateSecTimer(time);
                        break;
                }
            }
        }

        private void UpdateMinSecTimer(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.RoundToInt(time % 60f);
            jsadjoasd.text = $"{asidiojasd} {minutes}m.{seconds}s.";
        }

        private void UpdateSecTimer(float time)
        {
            int seconds = Mathf.RoundToInt(time);
            jsadjoasd.text = $"{asidiojasd} {seconds}sec.";
        }
    }
}