// Decompiled with JetBrains decompiler
// Type: Core.BombOnHitLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.Common.Extensions;
using Ensage.SDK.Extensions;
using Ensage.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechiesRage.Models;

namespace Core
{
  public static class BombOnHitLogic
  {
    public static void OnUpdate()
    {
      if (!Config._Menu.Features.DetonateOnHit)
        return;
      foreach (RemoteBomb remoteBomb in Config._RemoteBombs)
      {
        RemoteBomb B = remoteBomb;
        try
        {
          KeyValuePair<Unit, double> keyValuePair = Config._EnemyAttakers.Where(x =>
         {
             if (x.Key.IsAlive)
                 return x.Key.IsInAttackRange(B._Unit, 0.0f);
             return false;
         }).OrderBy(x => x.Key.FindRelativeAngle(B._Unit.Position)).FirstOrDefault();
          if (keyValuePair.Key != null)
          {
            if (B._Unit.DamageTaken(keyValuePair.Key.MaximumDamage + keyValuePair.Key.BonusDamage, DamageType.Physical, keyValuePair.Key, false, 0.0, 0.0, 0.0) >= (double) B._Unit.Health)
            {
              if (Game.RawGameTime >= (double) Ensage.Common.Extensions.UnitExtensions.AttackPoint(keyValuePair.Key) / 2.0 + keyValuePair.Value)
              {
                if (EntityManager<Unit>.Entities.Count(x =>
               {
                   if (x.Team != Config._Hero.Team)
                       return x.Distance2D(B._Unit, false) <= 400.0;
                   return false;
               }) >= 1)
                  B._Unit.Spellbook.Spell1.UseAbility();
              }
            }
          }
        }
        catch (Exception)
                {
        }
      }
    }
  }
}
