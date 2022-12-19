﻿using Input.Base;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Input
{
    public class GameplayInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<GameplayInputCommand>();

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new GameplayInputCommand.GameExit());
            }

            if (state.IsKeyDown(Keys.Left))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveLeft());
            }

            if (state.IsKeyDown(Keys.Right))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveRight());
            }

            if (state.IsKeyDown(Keys.Space))
            {
                commands.Add(new GameplayInputCommand.PlayerShoots());
            }

            if (state.IsKeyDown(Keys.Up))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveUp());
            }

            if (state.IsKeyDown(Keys.Down))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveDown());
            }

            return commands;
        }
    }
}
