using VContainer;
using VContainer.Unity;

namespace Source.Level
{
    public class LevelPresenter: IStartable, ITickable
    {
        [Inject] private readonly LevelFactory mqwklklmqwemklsda;

        private Level ksadlknlqwn;
        
        public void Start()
        {
            ksadlknlqwn = mqwklklmqwemklsda.Create();
        }

        public void Tick()
        {
            ksadlknlqwn.UpdateCells();
        }
    }
}