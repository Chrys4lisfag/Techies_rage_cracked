// Decompiled with JetBrains decompiler
// Type: Core.Logics.ForceLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Helpers;
using TechiesRage.Models;

namespace Core.Logics
{
  public static class ForceLogic
  {
    public static void OnUpdate()
    {
      if (Core.Config._Items.Force == null || !Core.Config._Items.Force.CanBeCasted)
        return;
      foreach (Hero hero in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
      {
        if (x.Team != Core.Config._Hero.Team && !x.IsIllusion)
          return TargetChecker.ForcePreCheck(x);
        return false;
      })))
      {
        Vector3 _Pos = hero.InFront(600f);
        if (hero.IsLinkensProtected())
        {
          if (Core.Config._Items.Hex != null && Core.Config._Items.Hex.IsReady && (double) Core.Config._Items.Hex.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false))
          {
            if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
            {
              Core.Config._Items.Hex.UseAbility((Unit) hero);
              break;
            }
          }
          else if (Core.Config._Items.Eul != null && Core.Config._Items.Eul.IsReady && (double) Core.Config._Items.Eul.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false))
          {
            if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
            {
              Core.Config._Items.Eul.UseAbility((Unit) hero);
              break;
            }
          }
          else if (Core.Config._Items.Salo != null && Core.Config._Items.Salo.IsReady && (double) Core.Config._Items.Salo.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false))
          {
            if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
            {
              Core.Config._Items.Salo.UseAbility((Unit) hero);
              break;
            }
          }
          else if (Core.Config._Items.Salo2 != null && Core.Config._Items.Salo2.IsReady && (double) Core.Config._Items.Salo2.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false))
          {
            if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
            {
              Core.Config._Items.Salo2.UseAbility((Unit) hero);
              break;
            }
          }
          else if (Core.Config._Items.Etherial != null && Core.Config._Items.Etherial.IsReady && (double) Core.Config._Items.Etherial.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false))
          {
            if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
            {
              Core.Config._Items.Etherial.UseAbility((Unit) hero);
              break;
            }
          }
          else
          {
            Item dagon = DagonManager.GetDagon();
            if ((Entity) dagon != (Entity) null && (double) dagon.Cooldown == 0.0 && (double) dagon.CastRange >= (double) Core.Config._Hero.Distance2D((Unit) hero, false) && (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos)))
            {
              Core.Config._Items.Dagon1.UseAbility((Unit) hero);
              break;
            }
          }
        }
        else if (ForceLogic.ShouldDetonate(hero, _Pos) || ForceLogic.ShouldDetonateLand(hero, _Pos) || ForceLogic.ShouldDetonateCross(hero, _Pos))
        {
          Core.Config._Items.Force.UseAbility((Unit) hero);
          break;
        }
      }
    }

    private static bool ShouldDetonate(Hero _Enemy, Vector3 _Pos)
    {
      foreach (BombStack bombStack in Core.Config._BombStacks)
      {
        BombStack _Stack = bombStack;
        if (!TargetChecker.CheckPos(_Enemy, _Stack))
          return false;
        if (_Stack.DetonateOnHeroes == 1)
        {
          List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x =>
          {
            if (x.IsHit(_Pos))
              return (double) x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
            return false;
          })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime)).ToList<RemoteBomb>();
          int kill = DamageManager.NeedToKill(_Enemy, list);
          if (list.Count >= kill)
            return true;
        }
        else
        {
          int num = 0;
          Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) x._Unit.Distance2D(_Stack._Unit, false) <= 100.0)).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime));
          foreach (Hero _Enemy1 in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
          {
            if (x.Team != Core.Config._Hero.Team && !x.IsIllusion && TargetChecker.ForcePreCheck(x))
              return TargetChecker.CheckPos(x, _Stack);
            return false;
          })))
          {
            List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x =>
            {
              if (x.IsHit(_Pos))
                return (double) x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
              return false;
            })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime)).ToList<RemoteBomb>();
            List<RemoteBomb> _Bombs = list;
            int kill = DamageManager.NeedToKill(_Enemy1, _Bombs);
            if (list.Count >= kill)
              ++num;
          }
          if (num >= _Stack.DetonateOnHeroes)
            return true;
        }
      }
      return false;
    }

    private static bool ShouldDetonateLand(Hero _Enemy, Vector3 _Pos)
    {
      if (!TargetChecker.PreCheck(_Enemy))
        return false;
      float num = DamageManager._LandDemage(_Enemy);
      return Core.Config._StasisBombs.Any<StasisBomb>((Func<StasisBomb, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0)) && (double) Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0)) * (double) num > (double) _Enemy.Health + (double) _Enemy.HealthRegeneration * 2.0;
    }

    private static bool ShouldDetonateCross(Hero _Enemy, Vector3 _Pos)
    {
      if (!TargetChecker.PreCheck(_Enemy))
        return false;
      float num1 = DamageManager._LandDemage(_Enemy);
      if (Core.Config._StasisBombs.Any<StasisBomb>((Func<StasisBomb, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0)))
      {
        float num2 = (float) Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(_Pos) <= 400.0)) * num1;
        int num3 = 0;
        int index = -1;
        foreach (string heroesFullName in Core.Config._HeroesFullNames)
        {
          if (heroesFullName == _Enemy.Name)
          {
            index = num3;
            break;
          }
          ++num3;
        }
        RemoteBomb[] array = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => x.IsHit(_Pos))).ToArray<RemoteBomb>();
        List<EnterInStack> source = new List<EnterInStack>();
        foreach (RemoteBomb remoteBomb in array)
        {
          RemoteBomb B = remoteBomb;
          BombStack _Temp = Core.Config._BombStacks.MinOrDefault<BombStack, float>((Func<BombStack, float>) (x => B._Unit.Distance2D(x._Unit, false)));
          if (_Temp != null && (double) _Temp._Unit.Distance2D(B._Unit, false) <= 100.0 && (index == -1 ? 1 : (_Temp._Disabler[index] ? 1 : 0)) == 0)
          {
            if (source.Any<EnterInStack>((Func<EnterInStack, bool>) (x => x.Stack.Id == _Temp.Id)))
            {
              if (!source.Any<EnterInStack>((Func<EnterInStack, bool>) (x => x.Bombs.Any<RemoteBomb>((Func<RemoteBomb, bool>) (y => (Entity) y._Unit == (Entity) B._Unit)))))
                source.First<EnterInStack>((Func<EnterInStack, bool>) (x => x.Stack.Id == _Temp.Id)).Bombs.Add(B);
            }
            else
            {
              EnterInStack enterInStack = new EnterInStack()
              {
                Bombs = new List<RemoteBomb>(),
                Stack = _Temp
              };
              enterInStack.Bombs.Add(B);
              source.Add(enterInStack);
            }
          }
        }
        float num4 = 0.0f;
        foreach (EnterInStack enterInStack in source)
        {
          if (enterInStack.Stack.DetonateOnHeroes == 1)
          {
            float num5 = enterInStack.Bombs.Sum<RemoteBomb>((Func<RemoteBomb, float>) (x => x._Damage)) * (1f - Core.Config._QSpell.GetDamageReduction((Unit) _Enemy));
            if ((double) num4 < (double) num5)
              num4 = num5;
          }
        }
        if ((double) num2 + (double) num4 > (double) _Enemy.Health + (double) _Enemy.HealthRegeneration * 2.0)
          return true;
      }
      return false;
    }
  }
}
