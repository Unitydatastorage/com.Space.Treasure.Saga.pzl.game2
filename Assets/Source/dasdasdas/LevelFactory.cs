using Source.Level.Mono;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Level
{
    public class LevelFactory
    {
        [Inject] private readonly IObjectResolver qwkksldlkasd;

        private Level joidqwjid;

        public Level Create()
        {
            joidqwjid = qwkksldlkasd.Resolve<Level>(); // Разрешаем зависимость Level через IObjectResolver
            Debug.Log("Level create: " + joidqwjid);
            return joidqwjid;
        }
    }
}