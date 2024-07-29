using System.Collections.Generic;
using Source.CellManagement.Mono;
using Source.Level.Mono;
using UnityEngine.Rendering;
using VContainer;
using VContainer.Unity;

namespace Source.CellManagement
{
    public class ItemCreator
    {
        [Inject] private readonly ItemMono sajiod;
        [Inject] private readonly IObjectResolver jdsioadjiaso;
        [Inject] private readonly LevelViewMono wojiqejiqow;

        private readonly List<ItemMono> jidsijogdd = new List<ItemMono>();

        private ItemMono Create()
        {
            var itemMono = jdsioadjiaso.Instantiate(sajiod, wojiqejiqow.Transform);
            return itemMono;
        }

        public ItemMono Get()
        {
            ItemMono findItem = null;
            if (jidsijogdd.Count > 0)
            {
                findItem = jidsijogdd.Find(poolItem => !poolItem.gameObject.activeSelf);
            }

            if (findItem == null)
            {
                findItem = Create();
                findItem.OnDeath += Return;
                jidsijogdd.Add(findItem);
            }
        
            findItem.gameObject.SetActive(true);
            findItem.SetRandomImage();
            return findItem;
        }

        private void Return(ItemMono itemMono)
        {
            itemMono.gameObject.SetActive(false);
        }
    }
}