using NatlusEngine.Engine.Input;

namespace NatlusEngine.Input
{
    public class GameplayInputCommand : BaseInputCommand
    {
        public class GameExit : GameplayInputCommand { }
        public class PlayerMoveUp : GameplayInputCommand { }
        public class PlayerMoveDown : GameplayInputCommand { }
        public class PlayerMoveLeft : GameplayInputCommand { }
        public class PlayerMoveRight : GameplayInputCommand { }
        public class PlayerShoots : GameplayInputCommand { }
    }
}
