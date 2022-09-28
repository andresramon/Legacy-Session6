namespace MarsRover
{
    public class MoveRear:ICommand
    {
        private ExplorerRover explorerRover;
        public MoveRear(ExplorerRover explorerRover)
        {
            this.explorerRover = explorerRover;
        }
        
        public void Execute()
        {
            explorerRover.MoveRear();
        }
    }
}