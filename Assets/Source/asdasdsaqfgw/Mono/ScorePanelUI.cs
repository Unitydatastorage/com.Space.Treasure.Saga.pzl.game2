using System;
using Source.Game;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Source.UI.Mono
{
    public class ScorePanelUI : MonoBehaviour
    {
        private GameStats ksdfkldsf;
        private GameSettingsScriptable ofdskopsda;
    
        [FormerlySerializedAs("itemCounter")] [SerializeField] private ItemCounter aosdpoasp;
        private ItemCounter[] afioasdfijoasdf;

        [Inject]
        private void Initialize(GameStats gameStats, GameSettingsScriptable gameSettingsScriptable)
        {
            this.ksdfkldsf = gameStats;
            this.ofdskopsda = gameSettingsScriptable;
            gameStats.ewioeqop += Ewioeqop;
            gameStats.JRQKWRMFDS += Jrqkwrmfds;
        }

        private void Jrqkwrmfds(int value, int maxValue, int id)
        {
            if (afioasdfijoasdf != null && afioasdfijoasdf.Length > id)
            {
                afioasdfijoasdf[id].UpdateCounter(value, maxValue);
            }
        }

        private void Ewioeqop()
        {
            if (afioasdfijoasdf != null && afioasdfijoasdf.Length > 0)
            {
                foreach (var counterUi in afioasdfijoasdf)
                {
                    Destroy(counterUi.gameObject);
                }
            }
            afioasdfijoasdf = new ItemCounter[ofdskopsda.EggSprites.Length];
        
            for (int i = 0; i < ofdskopsda.EggSprites.Length; i++)
            {
                afioasdfijoasdf[i] = Instantiate(aosdpoasp, transform);
                afioasdfijoasdf[i].SetSprite(ofdskopsda.EggSprites[i]);
            }
        }
    }
}