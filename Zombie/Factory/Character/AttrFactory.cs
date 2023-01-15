using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public class AttrFactory : IAttrFactory
    {
        private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict;
        public AttrFactory()
        {
            InitCharacterBaseAttr();
        }
        private void InitCharacterBaseAttr()
        {
            mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
            mCharacterBaseAttrDict.Add(typeof(EnemyZombie), new CharacterBaseAttr("丧尸", 100, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(BotanicRepeater), new CharacterBaseAttr("豌豆射手", 100, 2, 5, 25));
            mCharacterBaseAttrDict.Add(typeof(BotanicWallNut), new CharacterBaseAttr("坚果", 200, 2, 5, 25));
            mCharacterBaseAttrDict.Add(typeof(BotanicSnowPea), new CharacterBaseAttr("寒冰射手", 150, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(BucketheadZombie), new CharacterBaseAttr("铁桶丧尸", 150, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(FlagZombie), new CharacterBaseAttr("摇旗僵尸", 120, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(BotanicTallNut), new CharacterBaseAttr("高坚果", 300, 2, 10, 30));
            mCharacterBaseAttrDict.Add(typeof(BotanicFumeShroom), new CharacterBaseAttr("喷射菇", 100, 2, 10, 30));
        }
        public CharacterBaseAttr GetCharacterBaseAttr(Type t)
        {
            if (mCharacterBaseAttrDict.ContainsKey(t) == false)
            {
               return null;
            }
            return mCharacterBaseAttrDict[t];
        }
    }
}
