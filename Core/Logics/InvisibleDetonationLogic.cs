// Decompiled with JetBrains decompiler
// Type: Core.Logics.InvisibleDetonationLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Helpers;
using TechiesRage.Models;

namespace Core.Logics
{
  public static class InvisibleDetonationLogic
  {
    private static float LastDetonate;

    public static void OnUpdate()
    {
      try
      {
        if (!Core.Config._Menu.Features.DetonateOnInvisible || (double) InvisibleDetonationLogic.LastDetonate + 3.0 >= (double) Game.RawGameTime)
          return;
        foreach (LandBomb IvS in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => x._OnVision)))
        {
          IEnumerable<Unit> enemiesInRange = IvS._Unit.GetEnemiesInRange<Unit>(400f);
          Func<Unit, bool> func = x => !x.Name.Contains("caster");
          if (enemiesInRange.Where(func).Count() == 0)
                        Detonate(IvS);
        }
      }
      catch (Exception ex)
      {
        Core.Config.Log.Error(ex.ToString());
      }
    }

    private static void Detonate(LandBomb IvS)
    {
      foreach (BombStack bombStack in Core.Config._BombStacks)
      {
        BombStack _Stack = bombStack;
        if (_Stack.DetonateOnHeroes == 1)
        {
          int num = 0;
          List<RemoteBomb> list = Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x =>
          {
            if (x.IsHit(IvS._Unit.Position))
              return (double) x._Unit.Distance2D(_Stack._Unit, false) <= 100.0;
            return false;
          })).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime)).ToList<RemoteBomb>();
          foreach (Hero _Enemy in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
          {
            if (x.Team != Core.Config._Hero.Team && !x.IsIllusion && (!x.IsVisible && x.IsAlive))
              return x.IsValid;
            return false;
          })))
          {
            int kill = DamageManager.NeedToKill(_Enemy, list);
            if (list.Count >= kill && num < kill)
              num = kill;
          }
          if (num > 0)
          {
            Core.Config.Log.Warn("DetonateOnStack Invisible");
            InvisibleDetonationLogic.LastDetonate = Game.RawGameTime;
            foreach (RemoteBomb remoteBomb in list)
            {
              if (num > 0)
              {
                remoteBomb.Detonate();
                --num;
              }
              else
                break;
            }
          }
        }
      }
    }
  }
}
