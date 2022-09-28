namespace MarsRover
{
    public class RotateLeft:ICommand
    {
        private ExplorerRover explorerRover;
        public RotateLeft(ExplorerRover explorerRover)
        {
            this.explorerRover = explorerRover;
        }
        
        public void Execute()
        {
            explorerRover.RotateLeft();
        }
    }
}