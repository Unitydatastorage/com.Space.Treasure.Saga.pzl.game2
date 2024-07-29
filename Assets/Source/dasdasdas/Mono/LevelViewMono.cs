using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Level.Mono
{
    public class LevelViewMono : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        [FormerlySerializedAs("m_mergeSound")] [FormerlySerializedAs("_mergeSound")] [SerializeField] private AudioSource sdaijoas;

        private void Awake()
        {
            Transform = transform;
        }

        public void PlayAudioMerge()
        {
            sdaijoas?.Play();
        }
    }
}