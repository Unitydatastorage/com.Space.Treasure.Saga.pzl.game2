using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Source.UI.Mono
{
    public class ItemCounter : MonoBehaviour
    {
        [FormerlySerializedAs("itemImage")] [SerializeField] private Image gitemImage;
        [FormerlySerializedAs("scoreText")] [SerializeField] private TMP_Text dfasdsafdasf;

        public void SetSprite(Sprite sprite)
        {
            if (gitemImage != null)
            {
                gitemImage.sprite = sprite;
            }
        }

        public void UpdateCounter(int value, int maxValue)
        {
            if (dfasdsafdasf != null)
            {
                dfasdsafdasf.text = $"{value}/{maxValue}";
            }
        }
    }
}