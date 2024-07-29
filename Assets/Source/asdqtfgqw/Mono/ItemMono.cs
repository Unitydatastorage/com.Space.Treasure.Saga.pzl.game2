using System;
using Source.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using Random = UnityEngine.Random;

namespace Source.CellManagement.Mono
{
    public class ItemMono : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        private bool _isSwapping = false;
        public bool IsSwapping => _isSwapping;

        public Transform Transform { get; private set; }
        public int Index { get; private set; }

        private SpriteRenderer _spriteRenderer;

        public Action<ItemMono> OnDeath;

        [Inject] private GameSettingsScriptable _gameSettingsScriptable;

        private void Awake()
        {
            Transform = transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetRandomImage()
        {
            Index = UnityEngine.Random.Range(0, _gameSettingsScriptable.EggSprites.Length);
            _spriteRenderer.sprite = _gameSettingsScriptable.EggSprites[Index];
        }

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
    
        public bool Move(Vector3 position)
        {
            _isSwapping = Vector3.Distance(Transform.position, position) > 0.05f;
            Transform.position = Vector3.MoveTowards(Transform.position, position, Time.deltaTime * _moveSpeed);
            return _isSwapping;
        }

        public void Death()
        {
            OnDeath?.Invoke(this);
        }
    }
}