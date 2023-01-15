using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Zombie//外观模式，单例模式，程序运行时就调用，降低耦合度
{
    public class GameFacade
    {
        private static GameFacade _instance = new GameFacade();
        private bool mIsGameOver = false;
        private Form currform;
        public static GameFacade Insance { get { return _instance; } }

        public bool isGameOver { get { return mIsGameOver; } }

        public Form Currform { get => currform; set => currform = value; }
        public CampSystem MCampSystem { get => mCampSystem;}
        public int[] enyrowPos;
        public int[] botanyrowPos;
        private GameFacade() { }//四大子系统

        private CampSystem mCampSystem;
        private CharacterSystem mCharacterSystem;
        private SubscribeSystem mGameEventSystem;
         private StageSystem mStageSystem;
        public void Init()//让四大子系统执行初始化
        {
            mCampSystem = new CampSystem();
            mCharacterSystem = new CharacterSystem();  
            mGameEventSystem = new SubscribeSystem();
            mStageSystem = new StageSystem();
            mCampSystem.Init();
            mCharacterSystem.Init();
            mGameEventSystem.Init();
            mStageSystem.Init();
        }
        public void UpdateRender(Graphics g)
        {
            mCharacterSystem.UpdateRender(g);
        }
        
        public void Update()
        {
            mCampSystem.Update();
            mCharacterSystem.Update();
            mGameEventSystem.Update();
            mStageSystem.Update();
        }
        public void Release()//让四大子系统释放
        {
            mCampSystem.Release();
            mCharacterSystem.Release();
            mGameEventSystem.Release();
            mStageSystem.Release();
        }
        public void AddBotany(IBotany botany)//这些方法与各大子系统交互
        {
            mCharacterSystem.AddBotany (botany);
        }
        public void RemoveBotany(IBotany botany)
        {
            mCharacterSystem.RemoveBotany (botany);
        }
        public void AddBullet(IBullet bullet)
        {
            mCharacterSystem.AddBullt(bullet);
        }
        public void RemoveBullet(IBullet bullet)
        {
            mCharacterSystem.RemoveBullt(bullet);
        }
        public void AddEnemy(IEnemy enemy)
        {
            mCharacterSystem.AddEnemy(enemy);
        }
        public void RemoveEnemy(IEnemy enemy)
        {
            mCharacterSystem.RemoveEnemey(enemy);
        }
        public void RegisterObserver(GameEventType eventType, IObserver observer)
        {
            mGameEventSystem.RegisterObserver(eventType, observer);
        }
        public void RemoveObserver(GameEventType eventType, IObserver observer)
        {
            mGameEventSystem.RemoveObserver(eventType, observer);
        }
        public void NotifySubject(GameEventType eventType)
        {
            mGameEventSystem.NotifySubject(eventType);
        }
        public IBullet GetBullet(Type t,Point position, Point targetPosition, object fm)
        {
            IBullet blt= mCharacterSystem.GetBullet(t);
            if (blt != null)
            {
                mCharacterSystem.AddBullt(blt);
                blt.SetActive(position, targetPosition);
                //System.Diagnostics.Debug.WriteLine(false, "重复利用子弹");
            }
            if (blt == null && t.Name == "SingleBullet")
            {
                //System.Diagnostics.Debug.WriteLine(false, "生产子弹");
                blt = FactoryManager.BulletFactory.CreateBullet<SingleBullet>(position, targetPosition, fm);
            }
            if (blt == null && t.Name == "DoubleBullet")
            {
                //System.Diagnostics.Debug.WriteLine(false, "生产子弹");
                blt = FactoryManager.BulletFactory.CreateBullet<DoubleBullet>(position, targetPosition, fm);
            }
            if (blt == null && t.Name == "NbBullet")
            {
                //System.Diagnostics.Debug.WriteLine(false, "生产子弹");
                blt = FactoryManager.BulletFactory.CreateBullet<NbBullet>(position, targetPosition, fm);
            }
            return blt;
        }
    }
}
