using System;
using Source.Level.Mono;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Source.Game
{
    public class GameStats
    {
        [Inject] private readonly GameSettingsScriptable asijoasdijosda;
        private LevelScriptable jdoisajdoasi;
        private int sdaioojdasi;
        public int Sdaioojdasi => sdaioojdasi;

        private float iosajidsapoadsi;
        public float LevelTime => jdoisajdoasi.Duration;
        private int jasdioijsadoijaods;
        private int[] oiqwejqiowie;
        private int[] opetretyre;

        private bool dsoieqwmklqwe = false;
        public bool Dsoieqwmklqwe => dsoieqwmklqwe;

        public event Action ewioeqop, ASOPSDKOPOASKD, OIQWEQOWPRQWE, QWIOEIJORIOJERWT;
        public event Action<int, int> JQEWIOOPWQJROI;
        public event Action<int, int, int> JRQKWRMFDS;
        public event Action<float> URIUIEWWREKLMSDF;
        public event Action<int> JIQEWOQRDFSLS;

        public void UpdateTimer()
        {
            if (!dsoieqwmklqwe || !asijoasdijosda.TimerEnable) return;

            iosajidsapoadsi = Mathf.Clamp(iosajidsapoadsi - Time.deltaTime, 0, jdoisajdoasi.Duration);
            URIUIEWWREKLMSDF?.Invoke(iosajidsapoadsi);

            if (iosajidsapoadsi > 0) return;

            ASOPSDKOPOASKD?.Invoke();
            dsoieqwmklqwe = false;
            UpdateAllData();
        }

        public void AddScore(int value)
        {
            jasdioijsadoijaods = Mathf.Clamp(jasdioijsadoijaods + value, 0, jdoisajdoasi.MaxScore);
            JQEWIOOPWQJROI?.Invoke(jasdioijsadoijaods, jdoisajdoasi.MaxScore);

            if (jasdioijsadoijaods < jdoisajdoasi.MaxScore) return;

            PlayerPrefs.SetInt("Level_" + (sdaioojdasi + 1), 1);
            OIQWEQOWPRQWE?.Invoke();
            dsoieqwmklqwe = false;
            UpdateAllData();
        }

        public void AddScore(int value, int id)
        {
            if (id >= oiqwejqiowie.Length) return;

            opetretyre[id] = Mathf.Clamp(opetretyre[id] + value, 0, oiqwejqiowie[id]);
            Debug.Log($"{opetretyre[id]}/{oiqwejqiowie[id]}");
            JRQKWRMFDS?.Invoke(opetretyre[id], oiqwejqiowie[id], id);

            if (IsAllItemsComplete())
            {
                PlayerPrefs.SetInt("Level_" + (sdaioojdasi + 1), 1);
                OIQWEQOWPRQWE?.Invoke();
                dsoieqwmklqwe = false;
                UpdateAllData();
            }
        }

        public void StartLevel(int index)
        {
            sdaioojdasi = index;
            jdoisajdoasi = asijoasdijosda.LevelScriptables[sdaioojdasi];
            Restart();
        }

        public void NextLevel()
        {
            StartLevel(Mathf.Clamp(sdaioojdasi + 1, 0, asijoasdijosda.LevelScriptables.Length - 1));
        }

        public void Pause()
        {
            dsoieqwmklqwe = false;
        }

        public void Resume()
        {
            dsoieqwmklqwe = true;
        }

        public void Restart()
        {
            iosajidsapoadsi = jdoisajdoasi.Duration;

            if (asijoasdijosda.ByItemScore)
            {
                InitializeItemScores();
            }
            else
            {
                jasdioijsadoijaods = 0;
            }

            dsoieqwmklqwe = true;
            ewioeqop?.Invoke();
            UpdateAllData();
        }

        private void InitializeItemScores()
        {
            int itemCount = asijoasdijosda.EggSprites.Length;
            oiqwejqiowie = new int[itemCount];
            opetretyre = new int[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                oiqwejqiowie[i] = UnityEngine.Random.Range(jdoisajdoasi.MinScore, jdoisajdoasi.MaxScore);
            }
        }

        private bool IsAllItemsComplete()
        {
            for (int i = 0; i < asijoasdijosda.EggSprites.Length; i++)
            {
                if (opetretyre[i] != oiqwejqiowie[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateAllData()
        {
            URIUIEWWREKLMSDF?.Invoke(iosajidsapoadsi);

            if (asijoasdijosda.ByItemScore)
            {
                for (int i = 0; i < asijoasdijosda.EggSprites.Length; i++)
                {
                    JRQKWRMFDS?.Invoke(opetretyre[i], oiqwejqiowie[i], i);
                }
            }
            else
            {
                JQEWIOOPWQJROI?.Invoke(jasdioijsadoijaods, jdoisajdoasi.MaxScore);
            }

            JIQEWOQRDFSLS?.Invoke(sdaioojdasi + 1);
        }

        public void Menu()
        {
            dsoieqwmklqwe = false;
            QWIOEIJORIOJERWT?.Invoke();
        }
    }
}