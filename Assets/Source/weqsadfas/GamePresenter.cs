using VContainer;
using VContainer.Unity;

namespace Source.Game
{
    public class GamePresenter: ITickable
    {
        [Inject] private readonly GameStats joasdjiosad;

        public void Tick()
        {
            joasdjiosad.UpdateTimer();
        }
    }
}