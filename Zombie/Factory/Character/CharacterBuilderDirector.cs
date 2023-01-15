using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    class CharacterBuilderDirector
    {
        public static ICharacter Construct(ICharacterBuilder builder)
        {
            builder.AddCharacterAttr();
            builder.AddCharacterAnimate();
            builder.AddInCharacterSystem();
            return builder.GetResult();
        }
    }
}
