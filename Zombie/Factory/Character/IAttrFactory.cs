using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public interface IAttrFactory
    {
        CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
    }
}
