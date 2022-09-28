using System;

namespace MarsRover
{
    public class CommandFactory
    {
        private readonly static CommandFactory instance = new CommandFactory();

        public static CommandFactory Instance => instance;

        public ICommand GetCommand(string command, ExplorerRover explorerRover)
        {
            switch (command[0])
            {
                case 'A':
                    return new MoveAhead(explorerRover);
                case 'D':
                    return new RotateRight(explorerRover);
                case 'R':
                    return new MoveRear(explorerRover);
                case 'I':
                    return new RotateLeft(explorerRover);
                default:
                    throw new ArgumentOutOfRangeException(nameof(CommandFactory), command, null);
            }
        }
    }
}