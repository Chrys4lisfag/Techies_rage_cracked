// Decompiled with JetBrains decompiler
// Type: Core.BombManager
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Renderer.Particle;
using SharpDX;
using System;
using System.Linq;
using Core.Helpers;
using TechiesRage.Models;

namespace Core
{
  public static class BombManager
  {
    public static void AddBomb(Unit _Bomb, BombType _Type)
    {
      switch (_Type)
      {
        case BombType.Stasis:
          if (Config._StasisBombs.Any<StasisBomb>((Func<StasisBomb, bool>) (x => x._Unit.Equals((Entity) _Bomb))))
            break;
          Config._StasisBombs.Add(new StasisBomb()
          {
            _Unit = _Bomb
          });
          break;
        case BombType.Land:
          if (Config._LandBombs.Any<LandBomb>((Func<LandBomb, bool>) (x => x._Unit.Equals((Entity) _Bomb))))
            break;
          Config._LandBombs.Add(new LandBomb()
          {
            _Unit = _Bomb
          });
          break;
        case BombType.Remote:
          if (Config._RemoteBombs.Any<RemoteBomb>((Func<RemoteBomb, bool>) (x => x._Unit.Equals((Entity) _Bomb))))
            break;
          Config._RemoteBombs.Add(new RemoteBomb()
          {
            _Unit = _Bomb,
            _Damage = Config._RSpell.GetAbilitySpecialData("damage", Config._RSpell.Level) + (Config._Hero.HasAghanimsScepter() ? 150f : 0.0f)
          });
          Vector2 _UPos = HUDHelper.GetHPbarPosition(_Bomb);
          if (Config._BombStacks.FirstOrDefault<BombStack>((Func<BombStack, bool>) (x => (double) HUDHelper.GetHPbarPosition(x._Unit).Distance(_UPos) < 200.0)) != null)
            break;
          Config._BombStacks.Add(new BombStack(_Bomb)
          {
            Creeps = Config._Menu.DetonationMenu.CreepMenu.Creeps,
            Manta = Config._Menu.DetonationMenu.CreepMenu.Manta,
            Necro = Config._Menu.DetonationMenu.CreepMenu.Necro,
            HeroCreeps = Config._Menu.DetonationMenu.HeroCreepMenu.Creeps
          });
          break;
      }
    }

    public static void RemoveBomb(Unit _Bomb, BombType _Type)
    {
      switch (_Type)
      {
        case BombType.Stasis:
          StasisBomb stasisBomb = Config._StasisBombs.FirstOrDefault<StasisBomb>((Func<StasisBomb, bool>) (x => (Entity) x._Unit == (Entity) _Bomb));
          if (stasisBomb == null)
            break;
          if (Config._ParticleManager.HasParticle(stasisBomb._Unit.Handle.ToString()))
            Config._ParticleManager.Remove(stasisBomb._Unit.Handle.ToString());
          IParticleManager particleManager1 = Config._ParticleManager;
          string str1 = "st";
          uint handle = stasisBomb._Unit.Handle;
          string str2 = handle.ToString();
          string name1 = str1 + str2;
          if (particleManager1.HasParticle(name1))
          {
            IParticleManager particleManager2 = Config._ParticleManager;
            string str3 = "st";
            handle = stasisBomb._Unit.Handle;
            string str4 = handle.ToString();
            string name2 = str3 + str4;
            particleManager2.Remove(name2);
          }
          Config._StasisBombs.Remove(stasisBomb);
          break;
        case BombType.Land:
          LandBomb landBomb = Config._LandBombs.FirstOrDefault<LandBomb>((Func<LandBomb, bool>) (x => (Entity) x._Unit == (Entity) _Bomb));
          if (landBomb == null)
            break;
          if (Config._ParticleManager.HasParticle(landBomb._Unit.Handle.ToString()))
            Config._ParticleManager.Remove(landBomb._Unit.Handle.ToString());
          Config._LandBombs.Remove(landBomb);
          BombManager.ReBindLandStacker(_Bomb);
          break;
        case BombType.Remote:
          RemoteBomb remoteBomb = Config._RemoteBombs.FirstOrDefault<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit == (Entity) _Bomb));
          if (remoteBomb == null)
            break;
          if (Config._ParticleManager.HasParticle(remoteBomb._Unit.Handle.ToString()))
            Config._ParticleManager.Remove(remoteBomb._Unit.Handle.ToString());
          Config._RemoteBombs.Remove(remoteBomb);
          BombManager.ReBindStacker(_Bomb);
          break;
      }
    }

    public static void OnAddEntity(EntityEventArgs args)
    {
      Entity entity = args.Entity;
      if (entity.Team != Config._Hero.Team || entity.ClassId != ClassId.CDOTA_NPC_TechiesMines)
        return;
      if (entity.Name.IndexOf("stasis") > 0)
        BombManager.AddBomb((Unit) entity, BombType.Stasis);
      else if (entity.Name.IndexOf("land") > 0)
        BombManager.AddBomb((Unit) entity, BombType.Land);
      else
        BombManager.AddBomb((Unit) entity, BombType.Remote);
    }

    public static void OnRemoveEntity(EntityEventArgs args)
    {
      Entity entity = args.Entity;
      if (entity.Team == Config._Hero.Team && entity.ClassId == ClassId.CDOTA_NPC_TechiesMines)
      {
        if (entity.Name.IndexOf("stasis") > 0)
          BombManager.RemoveBomb((Unit) entity, BombType.Stasis);
        else if (entity.Name.IndexOf("land") > 0)
          BombManager.RemoveBomb((Unit) entity, BombType.Land);
        else
          BombManager.RemoveBomb((Unit) entity, BombType.Remote);
      }
      else
      {
        if (entity.Team == Config._Hero.Team)
          return;
        try
        {
          Unit key = (Unit) entity;
          if (!Config._EnemyAttakers.ContainsKey(key))
            return;
          Config._EnemyAttakers.Remove(key);
        }
        catch
        {
        }
      }
    }

    public static void Update()
    {
      foreach (Unit _Bomb in ObjectManager.GetEntitiesFast<Unit>().Where<Unit>((Func<Unit, bool>) (x =>
      {
        if (x.Team == Config._Hero.Team)
          return x.ClassId == ClassId.CDOTA_NPC_TechiesMines;
        return false;
      })).ToArray<Unit>())
      {
        if (_Bomb.Name.Contains("stasis"))
          BombManager.AddBomb(_Bomb, BombType.Stasis);
        else if (_Bomb.Name.Contains("land"))
          BombManager.AddBomb(_Bomb, BombType.Land);
        else
          BombManager.AddBomb(_Bomb, BombType.Remote);
      }
    }

    public static void OnInt32Change(Entity sender, Int32PropertyChangeEventArgs args)
    {
      if (sender.Team != Config._Hero.Team || sender.ClassId != ClassId.CDOTA_NPC_TechiesMines)
        return;
      if (args.PropertyName == "m_iHealth")
      {
        if (args.NewValue == 0)
        {
          if (sender.Name.Contains("stasis"))
            BombManager.RemoveBomb((Unit) sender, BombType.Stasis);
          else if (sender.Name.Contains("land"))
            BombManager.RemoveBomb((Unit) sender, BombType.Land);
          else
            BombManager.RemoveBomb((Unit) sender, BombType.Remote);
        }
        else
        {
          if (args.NewValue > 100 || !Config._Menu.Features.DetonateOnVision || (!sender.Name.Contains("remote") || ObjectManager.GetEntitiesFast<Unit>().Count<Unit>((Func<Unit, bool>) (x =>
          {
            if (x.Team != Config._Hero.Team)
              return (double) x.Distance2D((Unit) sender, false) < 400.0;
            return false;
          })) < 3))
            return;
          ((Unit) sender).Spellbook.Spell1.UseAbility();
        }
      }
      else if (args.PropertyName == "m_NetworkActivity")
      {
        if (args.NewValue != 1500)
          return;
        LandBomb landBomb = Config._LandBombs.FirstOrDefault<LandBomb>((Func<LandBomb, bool>) (z => (Entity) z._Unit == sender));
        if (landBomb == null || !landBomb._Unit.IsVisibleToEnemies)
          return;
        landBomb._OnVision = true;
        landBomb._VisionDate = Game.RawGameTime;
      }
      else
      {
        if (!(args.PropertyName == "m_iTaggedAsVisibleByTeam"))
          return;
        LandBomb landBomb = Config._LandBombs.FirstOrDefault<LandBomb>((Func<LandBomb, bool>) (z => (Entity) z._Unit == sender));
        if (landBomb == null)
          return;
        if (args.NewValue == 30)
        {
          landBomb._OnVision = true;
          landBomb._VisionDate = Game.RawGameTime;
        }
        else
          landBomb._OnVision = false;
      }
    }

    private static void ReBindStacker(Unit _Bomb)
    {
      BombStack _Stacker = Config._BombStacks.FirstOrDefault<BombStack>((Func<BombStack, bool>) (x => (int) x._Unit.Handle == (int) _Bomb.Handle));
      if (_Stacker == null)
        return;
      RemoteBomb _NewUnit = Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (Entity) x._Unit != (Entity) _Bomb)).MinOrDefault<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.Distance2D(_Stacker._Unit, false)));
      if (_NewUnit != null && (double) _NewUnit._Unit.Distance2D(_Stacker._Unit, false) < 100.0)
      {
        if (!Config._BombStacks.Where<BombStack>((Func<BombStack, bool>) (x => x.Id != _Stacker.Id)).Any<BombStack>((Func<BombStack, bool>) (x => (double) x._Unit.Distance2D(_NewUnit._Unit, false) <= 100.0)))
          _Stacker._Unit = _NewUnit._Unit;
        else
          Config._BombStacks.Remove(_Stacker);
      }
      else
        Config._BombStacks.Remove(_Stacker);
    }

    private static void ReBindLandStacker(Unit _Bomb)
    {
      LandStack _Stacker = Config._LandStacks.FirstOrDefault<LandStack>((Func<LandStack, bool>) (x => (int) x._Unit.Handle == (int) _Bomb.Handle));
      if (_Stacker == null)
        return;
      LandBomb _NewUnit = Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => (Entity) x._Unit != (Entity) _Bomb)).MinOrDefault<LandBomb, float>((Func<LandBomb, float>) (x => x._Unit.Distance2D(_Stacker._Unit, false)));
      if (_NewUnit != null && (double) _NewUnit._Unit.Distance2D(_Stacker._Unit, false) < 100.0)
      {
        if (!Config._LandStacks.Where<LandStack>((Func<LandStack, bool>) (x => x.Id != _Stacker.Id)).Any<LandStack>((Func<LandStack, bool>) (x => (double) x._Unit.Distance2D(_NewUnit._Unit, false) <= 100.0)))
          _Stacker._Unit = _NewUnit._Unit;
        else
          Config._LandStacks.Remove(_Stacker);
      }
      else
        Config._LandStacks.Remove(_Stacker);
    }
  }
}
