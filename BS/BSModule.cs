using Ninject.Modules;

namespace BS
{
    // DH: How many lines of code does this actually save?
    public class BSModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBoard>().To<Board>();
            Bind<IBoardWriter>().To<ConsoleBoardWriter>();
            Bind<IPlayerInput>().To<UserInput>();
            Bind<IPlayerInput>().To<ComputerInput>();
            Bind<Game>().ToSelf();
        }
    }
}