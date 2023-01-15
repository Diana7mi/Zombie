using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace Zombie
{
    class CharacterSystem:IGameSystem
    {
        private List<ICharacter> mEnemys = new List<ICharacter>();
        private List<ICharacter> mBotanys = new List<ICharacter>();
        private List<IBullet> launchhouse = new List<IBullet>();
        private List<IBullet> holehouse = new List<IBullet>();

        public void AddBullt(IBullet bt)
        {
            launchhouse.Add(bt);
        }
        public void RemoveBullt(IBullet bt)
        {
            launchhouse.Remove(bt);
            holehouse.Add(bt);
        }
        public void AddEnemy(IEnemy enemy)
        {
            mEnemys.Add(enemy);
        }
        public void RemoveEnemey(IEnemy enemy)
        {
            mEnemys.Remove(enemy);
        }
        public void AddBotany(IBotany soldier)
        {
            mBotanys.Add(soldier);
        }
        public void RemoveBotany(IBotany soldier)
        {
            mBotanys.Remove(soldier);
        }
        public void UpdateRender(Graphics g)
        {
            foreach (IEnemy e in mEnemys)
            {
                e.MAnim.Animatetion(g);
            }
            foreach (IBotany s in mBotanys)
            {
                s.MAnim.Animatetion(g);
            }
            foreach (IBullet e in launchhouse)
            {
                e.MAnim.Animatetion(g);
            }
        }
        public override void Update()
        {
            UpdateEnemy();
            UpdateBotanys();
            UpdateBullet();
            RemoveCharacterIsKilled(mEnemys);
            RemoveCharacterIsKilled(mBotanys);
            RemoveBulletIsOut();
        }
        private void UpdateEnemy()
        {
            foreach (IEnemy e in mEnemys)
            {
                e.Update();
                e.UpdateFSMAI(mBotanys);
            }
        }
        private void UpdateBotanys()
        {
            foreach (IBotany s in mBotanys)
            {
                s.Update();
                s.UpdateFSMAI(mEnemys);
            }
        }
        private void UpdateBullet()
        {
            foreach (IBullet e in launchhouse)
            {
                e.Update();
                e.UpdateCollsion(mEnemys);
            }
        }
        private void RemoveBulletIsOut()
        {
            
                List<IBullet> canDestroyes = new List<IBullet>();
                foreach (IBullet bullet in launchhouse)
                {
                    if (bullet.MCanDestroy)
                    {
                        canDestroyes.Add(bullet);
                        holehouse.Add(bullet);
                    }
                }
                foreach (IBullet bullet in canDestroyes)
                {

                    launchhouse.Remove(bullet);
                }
                
           
        }
        private void RemoveCharacterIsKilled(List<ICharacter> characters)
        {
            List<ICharacter> canDestroyes = new List<ICharacter>();
            foreach (ICharacter character in characters)
            {
                if (character.canDestroy)
                {
                    canDestroyes.Add(character);
                }
            }
            foreach (ICharacter character in canDestroyes)
            {
                character.Release();
                characters.Remove(character);
            }
        }
        public IBullet GetBullet(Type t)
        {
            if(holehouse.Count==0)
            return null;

            foreach (IBullet item in holehouse)
            {
                if(item.GetType()==t)
                {
                    holehouse.Remove(item);
                    return item;
                }
            }
            return null;
        }

    }
}
