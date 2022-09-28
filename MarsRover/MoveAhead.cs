namespace MarsRover
{
    public class MoveAhead:ICommand
    {
        private ExplorerRover explorerRover;
        public MoveAhead(ExplorerRover explorerRover)
        {
            this.explorerRover = explorerRover;
        }
        
        public void Execute()
        {
            explorerRover.MoveAhead();
        }
    }
}