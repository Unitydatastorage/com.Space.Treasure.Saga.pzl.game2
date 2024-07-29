using Source.Game;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.UI.Mono
{
    public class TimerToggle : MonoBehaviour
    {
        [FormerlySerializedAs("onImage")] [SerializeField] private Image idsaiojdsajioasd;
        [FormerlySerializedAs("offImage")] [SerializeField] private Image jadsjiosadijodas;
        [FormerlySerializedAs("key")] [SerializeField] private string oijdasijodas;
        [FormerlySerializedAs("gameSettingsScriptable")] [SerializeField] private GameSettingsScriptable psoidasp;
    
        private Toggle toggle;
    
        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(ValueChange);
            toggle.isOn = PlayerPrefs.GetInt(oijdasijodas, 1) == 1;
            ValueChange(toggle.isOn);
        }

        public void ValueChange(bool value)
        {
            idsaiojdsajioasd.enabled = value;
            jadsjiosadijodas.enabled = !value;
            PlayerPrefs.SetInt(oijdasijodas, value ? 1 : 0);
            psoidasp.TimerEnable = value;
        }

        private void OnEnable()
        {
            toggle.isOn = PlayerPrefs.GetInt(oijdasijodas, 1) == 1;
        }
    }
}