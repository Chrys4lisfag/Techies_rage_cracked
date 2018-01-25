// Decompiled with JetBrains decompiler
// Type: Core.Logics.LandRunKillLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Linq;
using Core.Helpers;
using TechiesRage.Models;

namespace Core.Logics
{
  public static class LandRunKillLogic
  {
    public static void OnUpdate()
    {
      foreach (LandStack landStack in Core.Config._LandStacks.Where<LandStack>((Func<LandStack, bool>) (x => x.MoveForKill)))
      {
        LandStack _SB = landStack;
        Hero hero = EntityManager<Hero>.Entities.FirstOrDefault<Hero>((Func<Hero, bool>) (x =>
        {
          if (x.Team != Core.Config._Hero.Team && TargetChecker.PreCheck(x))
            return (double) x.Distance2D(_SB._Unit.Position) <= 450.0;
          return false;
        }));
        if ((Entity) hero != (Entity) null)
        {
          _SB.IsRunToKill = true;
          foreach (LandBomb landBomb in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(_SB._Unit, false) <= 450.0)))
            landBomb._Unit.Move(hero.Position);
        }
        else if (_SB.IsRunToKill)
        {
          _SB.IsRunToKill = false;
          foreach (LandBomb landBomb in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(_SB._Unit, false) <= 450.0)))
            landBomb._Unit.Stop();
        }
      }
    }
  }
}
