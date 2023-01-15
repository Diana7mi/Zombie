using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    public class BotanyFactory : ICharacterFactory
    {
        public ICharacter CreateCharacter<T>(Point spawnPosition,int posRow ,object fm) where T : ICharacter, new()
        {
            ICharacter character = new T();
            ICharacterBuilder builder = new BotanyBuilder(character, typeof(T), spawnPosition, posRow,fm);
            return CharacterBuilderDirector.Construct(builder);
        }
    }
}
