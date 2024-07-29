using Source.CellManagement;
using Source.CellManagement.Mono;
using Source.Game;
using Source.Level;
using Source.Level.Mono;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Source.rwqsad
{
    public class GameLifetimeScope : LifetimeScope
    {
        [FormerlySerializedAs("_cellViewMonoPrefab")] [SerializeField] private CellViewMono jsadoiojads;
        [FormerlySerializedAs("_itemMonoPrefab")] [SerializeField] private ItemMono oasdokpads;
        [FormerlySerializedAs("_levelViewMono")] [SerializeField] private LevelViewMono jsadijisaod;

        [FormerlySerializedAs("_gameSettingsScriptable")] [SerializeField] private GameSettingsScriptable jaosdisadjio;

        protected override void Configure(IContainerBuilder builder)
        {
            // Регистрация точек входа
            RegisterEntryPoint(builder);

            // Регистрация singleton-ов
            RegisterSingleton(builder);

            // Регистрация скоупов
            builder.Register<Level.Level>(Lifetime.Scoped);

            // Регистрация компонентов
            RegisterComponents(builder);
        }

        private static void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelPresenter>();
            builder.RegisterEntryPoint<GamePresenter>();
        }

        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponent(jsadoiojads);
            builder.RegisterComponent(oasdokpads);
            builder.RegisterComponent(jsadijisaod);
            builder.RegisterComponent(jaosdisadjio);
        }

        private static void RegisterSingleton(IContainerBuilder builder)
        {
            builder.Register<LevelFactory>(Lifetime.Singleton);
            builder.Register<CellsCreator>(Lifetime.Singleton);
            builder.Register<ItemCreator>(Lifetime.Singleton);
            builder.Register<GameStats>(Lifetime.Singleton);
        }
    }
}
