namespace MarsRover
{
    public class RotateRight:ICommand
    {
        private ExplorerRover explorerRover;
        public RotateRight(ExplorerRover explorerRover)
        {
            this.explorerRover = explorerRover;
        }
        
        public void Execute()
        {
            explorerRover.RotateRight();
        }
    }
}