using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter<T>(Point spawnPosition,int posRow,object fm) where T : ICharacter, new();
    }
}
