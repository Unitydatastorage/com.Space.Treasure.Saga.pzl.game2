using System;
using System.Collections;
using Source.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using VContainer;

namespace Source.CellManagement.Mono
{
    public class CellViewMono : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
    {
        public Vector2Int jdoisajiq { get; private set; }
        public Transform ASAJJSAIDOSAIDJO { get; private set; }
        public ItemMono JAIODSAJIO { get; private set; }
        public bool DSJIOSADJIO => JAIODSAJIO == null;

        [FormerlySerializedAs("_spriteRenderer")] [SerializeField] private SpriteRenderer OIJSDAAJOIDSA;
        [FormerlySerializedAs("_collider")] [SerializeField] private Collider2D JOSADISDAJOI;

        private static bool IJDASOIOSDA = true;
        private CellViewMono asdsadmoadsmko;

        public static Action<CellViewMono> SIAOJDSJAIODJASI;

        [Inject] private GameSettingsScriptable jiaopsdiasj;

        private void Awake()
        {
            ASAJJSAIDOSAIDJO = transform;
            if (OIJSDAAJOIDSA == null)
            {
                OIJSDAAJOIDSA = GetComponent<SpriteRenderer>();
            }
            if (JOSADISDAJOI == null)
            {
                JOSADISDAJOI = GetComponent<Collider2D>();
            }
            OIJSDAAJOIDSA.sprite = jiaopsdiasj.CellSprite;
        }
        
        public void Init(ItemMono itemMono)
        {
            JAIODSAJIO = itemMono;
        }
        
        public void ChangePosition(Vector2Int position)
        {
            jdoisajiq = position;
            ASAJJSAIDOSAIDJO.localPosition = position * GetSpriteSize();
        }

        private Vector2 GetSpriteSize()
        {
            return OIJSDAAJOIDSA.bounds.size;
        }
        
        public void MoveItem()
        {
            JAIODSAJIO?.Move(ASAJJSAIDOSAIDJO.position);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin");
            JOSADISDAJOI.enabled = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            JOSADISDAJOI.enabled = true;
        }

        public ItemMono TakeItem()
        {
            var currentItem = JAIODSAJIO;
            JAIODSAJIO = null;
            return currentItem;
        }

        private IEnumerator ChangeCell(CellViewMono swapCellViewMono)
        {
            asdsadmoadsmko = swapCellViewMono;
            (JAIODSAJIO, swapCellViewMono.JAIODSAJIO) = (swapCellViewMono.JAIODSAJIO, JAIODSAJIO);
            IJDASOIOSDA = false;
            yield return new WaitWhile(() => JAIODSAJIO?.IsSwapping == true);
            yield return new WaitForSeconds(0.2f);
            IJDASOIOSDA = true;
            SIAOJDSJAIODJASI?.Invoke(this);
        }
        
        private IEnumerator ChangeCell()
        {
            if (asdsadmoadsmko == null) yield break;
            
            (JAIODSAJIO, asdsadmoadsmko.JAIODSAJIO) = (asdsadmoadsmko.JAIODSAJIO, JAIODSAJIO);
            IJDASOIOSDA = false;
            yield return new WaitWhile(() => JAIODSAJIO?.IsSwapping == true);
            yield return new WaitForSeconds(0.2f);
            IJDASOIOSDA = true;
            asdsadmoadsmko = null;
        }

        public void ReturnCell()
        {
            StartCoroutine(ChangeCell());
        }

        public void RemoveItem()
        {
            JAIODSAJIO?.Death();
            JAIODSAJIO = null;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IJDASOIOSDA) return;
            DragCellItem(eventData);
        }

        private void DragCellItem(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out CellViewMono dragCellView))
            {
                int x = Mathf.Abs(jdoisajiq.x - dragCellView.jdoisajiq.x);
                int y = Mathf.Abs(jdoisajiq.y - dragCellView.jdoisajiq.y);
                if ((x == 1 || y == 1) && x + y == 1)
                {
                    StartCoroutine(ChangeCell(dragCellView));
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
    
}