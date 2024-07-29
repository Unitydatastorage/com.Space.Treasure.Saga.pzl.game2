using System;
using Source.Audio.Mono;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.UI.Mono
{
    public class AudioToggle : MonoBehaviour
    {
        [FormerlySerializedAs("_onImage")] [SerializeField] private Image n_onImage;
        [FormerlySerializedAs("_offImage")] [SerializeField] private Image m_offImage;
        [FormerlySerializedAs("_key")] [SerializeField] private string s_key;
        [FormerlySerializedAs("_musicManagers")] [SerializeField] private AudioSourceManager[] a_musicManagers;

        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(ValueChange);
            _toggle.isOn = PlayerPrefs.GetInt(s_key, 1) == 1; // Устанавливаем состояние переключателя из PlayerPrefs
            ValueChange(_toggle.isOn); // Вызываем обработчик изменения значения
        }

        private void OnEnable()
        {
            _toggle.isOn = PlayerPrefs.GetInt(s_key, 1) == 1; // При включении объекта обновляем состояние переключателя из PlayerPrefs
        }

        public void ValueChange(bool value)
        {
            n_onImage.enabled = value; // Включаем или выключаем изображение для включенного состояния
            m_offImage.enabled = !value; // Включаем или выключаем изображение для выключенного состояния
            foreach (var musicManager in a_musicManagers)
            {
                musicManager.ToggleActive(value); // Вызываем метод ToggleActive для всех указанных AudioSourceManager
            }
        }
    }
}