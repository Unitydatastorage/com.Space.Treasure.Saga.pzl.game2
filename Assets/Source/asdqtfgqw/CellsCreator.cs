using Source.CellManagement.Mono;
using Source.Level.Mono;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.CellManagement
{
    public class CellsCreator
    {
        [Inject] private readonly CellViewMono jiojdsajiodsa;
        [Inject] private readonly LevelViewMono dsiodasjioasdioj;
        [Inject] private readonly IObjectResolver jisdaiojdsaijo;

        public CellViewMono Generate(Vector2Int position)
        {
            var cellViewMono = jisdaiojdsaijo.Instantiate(jiojdsajiodsa, dsiodasjioasdioj.Transform);
            cellViewMono.ChangePosition(position);
            return cellViewMono;
        }
    }
}