// Decompiled with JetBrains decompiler
// Type: TechiesRage.TechiesRage
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.Common.Extensions;
using Ensage.SDK.Handlers;
using Ensage.SDK.Helpers;
using Ensage.SDK.Input;
using Ensage.SDK.Inventory;
using Ensage.SDK.Menu;
using Ensage.SDK.Renderer.Particle;
using Ensage.SDK.Service;
using Ensage.SDK.Service.Metadata;
using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Logics;
using TechiesRage.Drawings;
using TechiesRage.Models;

namespace TechiesRage
{
    [ExportPlugin("Techies Rage", StartupMode.Auto, "SirLimon", "1.3.3.0", "Techies smart assembly", 500, new HeroId[] { HeroId.npc_dota_hero_techies })]
    internal class TechiesRage : Plugin
    {
        private readonly Lazy<MenuManager> _MenuManager;
        private readonly IServiceContext _Context;
        private readonly IInputManager _Input;
        private readonly IInventoryManager _InventoryManager;

        [ImportingConstructor]
        public TechiesRage([Import] IServiceContext _Context, [Import] Lazy<MenuManager> _MenuManager)
        {
            Core.Config._Hero = (Hero)_Context.Owner;
            this._MenuManager = _MenuManager;
            this._Context = _Context;
            Core.Config._Renderer = _Context.Renderer;
            Core.Config._ParticleManager = _Context.Particle;
            this._Input = _Context.Input;
            Core.Config._TargetSelector = _Context.TargetSelector;
            this._InventoryManager = _Context.Inventory;
            Core.Config._QSpell = Core.Config._Hero.Spellbook.SpellQ;
            Core.Config._WSpell = Core.Config._Hero.Spellbook.SpellW;
            Core.Config._ESpell = Core.Config._Hero.Spellbook.SpellE;
            Core.Config._RSpell = Core.Config._Hero.Spellbook.SpellR;
        }

        protected override void OnActivate()
        {
            try
            {
                Core.Init.Prepare();
                Core.Config._Menu = new Core.Menus.Menu();
                this._Context.MenuManager.RegisterMenu((object)Core.Config._Menu);
                this._Input.MouseClick += new EventHandler<MouseEventArgs>(MouseRegionCatch.Input_MouseClick);
                Core.Config._Renderer.Draw += new EventHandler(Drawings.BombStack.OnDraw);
                Core.Config._Renderer.Draw += new EventHandler(Drawings.LandStack.OnDraw);
                Core.Config._Renderer.Draw += new EventHandler(LandTimer.OnDraw);
                Core.Config._Renderer.Draw += new EventHandler(Info.OnDraw);
                Core.Config._Renderer.Draw += new EventHandler(Hello.OnDraw);
                ObjectManager.OnAddEntity += new ObjectManagerAddEntity(BombManager.OnAddEntity);
                ObjectManager.OnRemoveEntity += new ObjectManagerRemoveEntity(BombManager.OnRemoveEntity);
                Entity.OnInt32PropertyChange += new EntityInt32PropertyChange(BombManager.OnInt32Change);
                UpdateManager.Subscribe(new Action(BombOnHitLogic.OnUpdate), 25, true);
                UpdateManager.Subscribe(new Action(LandRunKillLogic.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(CreepDetonationLogic.OnUpdate), 200, true);
                UpdateManager.Subscribe(new Action(ForceLogic.OnUpdate), 50, true);
                UpdateManager.Subscribe(new Action(BombOnHitLogic.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(ModWatcherLogic.OnUpdate), 50, true);
                UpdateManager.BeginInvoke(new Action(this.DetonationLoop), 0);
                UpdateManager.Subscribe(new Action(InvisibleDetonationLogic.OnUpdate), 50, true);
                UpdateManager.Subscribe(new Action(Drawings.BombStack.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(Drawings.LandStack.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(Bombs.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(Force.OnUpdate), 50, true);
                UpdateManager.Subscribe(new Action(EULCombo.OnUpdate), 100, true);
                UpdateManager.Subscribe(new Action(ParticleRemover.OnUpdate), 1000, true);
                UpdateManager.Subscribe(new Action(EnemyUpdater.OnUpdate), 5000, true);
                Core.Config._EULComboTask = new TaskHandler(new Func<CancellationToken, Task>(EULComboLogic.OnUpdateTask), true);
                this._InventoryManager.Attach((object)Core.Config._Items);
                Entity.OnAnimationChanged += new EntityAnimationChanged(TechiesRage.OnAnimationChanged);
                BombManager.Update();
                Task.Run((Func<Task>)(async () =>
               {
                   await Task.Delay(15000);
                   Core.Config._Hello = false;
               }));
                Core.Config.Log.Warn("Load completed");
                Printer.Print("Please read docs for Techies Rage at RageScript.pro", false);
                Printer.Print("And check your detonation mode in menu/features", false);
            }
            catch (Exception ex)
            {
                Core.Config.Log.Error(ex.ToString());
            }
        }

        protected override void OnDeactivate()
        {
            this._MenuManager.Value.DeregisterMenu((object)Core.Config._Menu, true);
            this._Input.MouseClick -= new EventHandler<MouseEventArgs>(MouseRegionCatch.Input_MouseClick);
            Core.Config._Renderer.Draw -= new EventHandler(Drawings.BombStack.OnDraw);
            Core.Config._Renderer.Draw -= new EventHandler(Drawings.LandStack.OnDraw);
            Core.Config._Renderer.Draw -= new EventHandler(LandTimer.OnDraw);
            Core.Config._Renderer.Draw -= new EventHandler(Info.OnDraw);
            Core.Config._Renderer.Draw -= new EventHandler(Hello.OnDraw);
            UpdateManager.Unsubscribe(new Action(LandRunKillLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(BombOnHitLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(CreepDetonationLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(ForceLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(BombOnHitLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(ModWatcherLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(InvisibleDetonationLogic.OnUpdate));
            UpdateManager.Unsubscribe(new Action(Drawings.BombStack.OnUpdate));
            UpdateManager.Unsubscribe(new Action(Drawings.LandStack.OnUpdate));
            UpdateManager.Unsubscribe(new Action(Bombs.OnUpdate));
            UpdateManager.Unsubscribe(new Action(Force.OnUpdate));
            UpdateManager.Unsubscribe(new Action(EULCombo.OnUpdate));
            UpdateManager.Unsubscribe(new Action(ParticleRemover.OnUpdate));
            UpdateManager.Unsubscribe(new Action(EnemyUpdater.OnUpdate));
            this._InventoryManager.Detach((object)Core.Config._Items);
            Entity.OnAnimationChanged -= new EntityAnimationChanged(TechiesRage.OnAnimationChanged);
            ObjectManager.OnAddEntity -= new ObjectManagerAddEntity(BombManager.OnAddEntity);
            ObjectManager.OnRemoveEntity -= new ObjectManagerRemoveEntity(BombManager.OnRemoveEntity);
            Entity.OnInt32PropertyChange -= new EntityInt32PropertyChange(BombManager.OnInt32Change);
            foreach (Models.BombStack bombStack in Core.Config._BombStacks)
                Core.Config._ParticleManager.Remove(bombStack.Id.ToString());
            foreach (Models.LandStack landStack in Core.Config._LandStacks)
                Core.Config._ParticleManager.Remove(landStack.Id.ToString());
            foreach (LandBomb landBomb in Core.Config._LandBombs)
            {
                IParticleManager particleManager1 = Core.Config._ParticleManager;
                uint handle = landBomb._Unit.Handle;
                string name1 = handle.ToString();
                if (particleManager1.HasParticle(name1))
                {
                    IParticleManager particleManager2 = Core.Config._ParticleManager;
                    handle = landBomb._Unit.Handle;
                    string name2 = handle.ToString();
                    particleManager2.Remove(name2);
                }
            }
            foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs)
            {
                IParticleManager particleManager1 = Core.Config._ParticleManager;
                uint handle = remoteBomb._Unit.Handle;
                string name1 = handle.ToString();
                if (particleManager1.HasParticle(name1))
                {
                    IParticleManager particleManager2 = Core.Config._ParticleManager;
                    handle = remoteBomb._Unit.Handle;
                    string name2 = handle.ToString();
                    particleManager2.Remove(name2);
                }
            }
            foreach (StasisBomb stasisBomb in Core.Config._StasisBombs)
            {
                IParticleManager particleManager1 = Core.Config._ParticleManager;
                uint handle = stasisBomb._Unit.Handle;
                string name1 = handle.ToString();
                if (particleManager1.HasParticle(name1))
                {
                    IParticleManager particleManager2 = Core.Config._ParticleManager;
                    handle = stasisBomb._Unit.Handle;
                    string name2 = handle.ToString();
                    particleManager2.Remove(name2);
                }
                IParticleManager particleManager3 = Core.Config._ParticleManager;
                handle = stasisBomb._Unit.Handle;
                string name3 = handle.ToString();
                if (particleManager3.HasParticle(name3))
                    Core.Config._ParticleManager.Remove("st" + (object)stasisBomb._Unit.Handle);
            }
            this._InventoryManager.Detach((object)Core.Config._Items);
        }

        private static void OnAnimationChanged(Entity sender, EventArgs args)
        {
            if (sender.Team == Core.Config._Hero.Team || !sender.Animation.Name.Contains("attack") && sender.Animation.Name != "radiant_tower002")
                return;
            Unit index = sender as Unit;
            if ((Entity)index == (Entity)null || !index.IsAttacking())
                return;
            if (!Core.Config._EnemyAttakers.ContainsKey(index))
                Core.Config._EnemyAttakers.Add(index, 0.0);
            else
                Core.Config._EnemyAttakers[index] = (double)Game.RawGameTime;
        }

        private async void DetonationLoop()
        {
            TechiesRage techiesRage = this;
            while (techiesRage.IsActive)
            {
                await DetonationLogic.OnUpdateAsync();
                await Task.Delay(50);
                await Task.Delay(50);
            }
        }
    }
}
