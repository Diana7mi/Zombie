using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public static class FactoryManager
    {
        
        private static ICharacterFactory botanyFactory = null;
        private static ICharacterFactory enemyFactory = null;
        private static IAttrFactory attrFactory = null;
        private static BulletAttrFactory bulletAttrFactory = null;
        private static IBulletFactory bulletFactory = null;
        public static BulletAttrFactory BulletAttrFactory
        {
            get
            {
                if (bulletAttrFactory == null)
                {
                    bulletAttrFactory = new BulletAttrFactory();
                }
                return bulletAttrFactory;
            }
        }
        public static IAttrFactory AttrFactory
        {
            get
            {
                if (attrFactory == null)
                {
                    attrFactory = new AttrFactory();
                }
                return attrFactory;
            }
        }

        
        public static ICharacterFactory BotanyFactory
        {
            get
            {
                if (botanyFactory == null)
                {
                    botanyFactory = new BotanyFactory();
                }
                return botanyFactory;
            }
        }
        public static ICharacterFactory EnemyFactory
        {
            get
            {
                if (enemyFactory == null)
                {
                    enemyFactory = new EnemyFactory();
                }
                return enemyFactory;
            }
        }

        public static IBulletFactory BulletFactory
        {
            get
            {
                if (bulletFactory == null)
                {
                    bulletFactory = new IBulletFactory();
                }
                return bulletFactory;
            }
        }
    }
}
