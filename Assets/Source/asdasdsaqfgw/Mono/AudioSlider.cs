using Source.Audio.Mono;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.UI.Mono
{
    public class AudioSlider : MonoBehaviour
    {
        [FormerlySerializedAs("_key")] [SerializeField] private string m_key;
        [FormerlySerializedAs("audioSourceManager")] [SerializeField] private AudioSourceManager maudioSourceManager;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(ValueChange);
            _slider.value = PlayerPrefs.GetFloat(m_key, 1f); // Устанавливаем значение слайдера из PlayerPrefs
            ValueChange(_slider.value); // Вызываем обработчик изменения значения
        }

        private void OnEnable()
        {
            _slider.value = PlayerPrefs.GetFloat(m_key, 1f); // При включении объекта обновляем значение слайдера из PlayerPrefs
        }

        public void ValueChange(float value)
        {
            maudioSourceManager.SmoothChange(value); // Вызываем метод SmoothChange для изменения громкости
        }
    }
}