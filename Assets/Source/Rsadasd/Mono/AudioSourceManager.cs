using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Audio.Mono
{
    public class AudioSourceManager : MonoBehaviour
    {
        [FormerlySerializedAs("m_аudioSource")] [FormerlySerializedAs("_musicAudio")] [SerializeField] private AudioSource asiodjsadjio;
        [FormerlySerializedAs("m_key")] [FormerlySerializedAs("_key")] [SerializeField] private string ojdasiiajsod;
        [FormerlySerializedAs("m_muteKey")] [FormerlySerializedAs("_muteKey")] [SerializeField] private string jiasdojaosdi;

        private int jsaiodsadjoi;
        private float dsjasajido;

        private void Start()
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            jsaiodsadjoi = PlayerPrefs.GetInt(jiasdojaosdi, 1);
            dsjasajido = PlayerPrefs.GetFloat(ojdasiiajsod, 1.0f);
            ApplySettings();
        }

        private void ApplySettings()
        {
            asiodjsadjio.mute = (jsaiodsadjoi == 0);
            asiodjsadjio.volume = dsjasajido;
        }

        public void ToggleActive(bool value)
        {
            jsaiodsadjoi = value ? 1 : 0;
            PlayerPrefs.SetInt(jiasdojaosdi, jsaiodsadjoi);
            asiodjsadjio.mute = !value;
        }

        public void SmoothChange(float val)
        {
            dsjasajido = val;
            PlayerPrefs.SetFloat(ojdasiiajsod, dsjasajido);
            asiodjsadjio.volume = dsjasajido;
        }
    }
}