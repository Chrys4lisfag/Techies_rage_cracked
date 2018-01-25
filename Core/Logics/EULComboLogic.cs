// Decompiled with JetBrains decompiler
// Type: Core.Logics.EULComboLogic
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using SharpDX;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Helpers;
using TechiesRage.Models;
using Ensage.SDK.Geometry;

namespace Core.Logics
{
  public static class EULComboLogic
  {
    public static int _Status;
    public static Hero _Enemy;
    public static Vector3 _JPos;
    private static float _JTime;
    private static bool _S2Switch;
    private static float _InitHP;

    public static async Task OnUpdateTask(CancellationToken cancellationToken)
    {
      switch (EULComboLogic._Status)
      {
        case 0:
          if ((double) Core.Config._ESpell.Cooldown != 0.0 || (double) Core.Config._WSpell.Cooldown != 0.0 || !Core.Config._Items.Eul.CanBeCasted)
          {
            await Task.Delay(100);
            break;
          }
          EULComboLogic._Enemy = (Hero) Core.Config._TargetSelector.Active.GetTargets().FirstOrDefault<Unit>((Func<Unit, bool>) (x => (double) x.Distance2D((Unit) Core.Config._Hero, false) <= (double) (Core.Config._ESpell.CastRange + 300U)));
          if ((Entity) EULComboLogic._Enemy == (Entity) null || (double) DamageManager._SuicideDemage(EULComboLogic._Enemy) < 100.0)
            break;
          EULComboLogic._JPos = !EULComboLogic._Enemy.IsMoving ? EULComboLogic._Enemy.Position : EULComboLogic._Enemy.InFront(1.75f * (float) EULComboLogic._Enemy.MovementSpeed);
          EULComboLogic._JTime = Game.RawGameTime;
          Core.Config._ESpell.UseAbility(EULComboLogic._JPos);
          EULComboLogic._Status = 1;
          EULComboLogic._S2Switch = false;
          await Task.Delay(50);
          break;
        case 1:
          if (!Core.Config._ESpell.IsInAbilityPhase && (double) Core.Config._ESpell.Cooldown != 0.0 && EULComboLogic._S2Switch)
          {
            EULComboLogic._InitHP = (float) Core.Config._Hero.Health;
            EULComboLogic._Status = 2;
          }
          EULComboLogic._S2Switch = true;
          if ((double) EULComboLogic._JTime + 0.75 < (double) Game.RawGameTime)
          {
            if (EULComboLogic._Enemy.IsMoving)
            {
              if ((double) EULComboLogic._Enemy.InFront(1.75f * (float) EULComboLogic._Enemy.MovementSpeed).Distance2D(EULComboLogic._JPos, false) > 200.0)
              {
                Core.Config._Hero.Stop();
                EULComboLogic._Status = 0;
              }
            }
            else if ((double) EULComboLogic._Enemy.Distance2D(EULComboLogic._JPos) > 200.0)
            {
              Core.Config._Hero.Stop();
              EULComboLogic._Status = 0;
            }
          }
          await Task.Delay(50);
          break;
        case 2:
          if ((double) EULComboLogic._InitHP > (double) EULComboLogic._InitHP / 1.5)
            await Task.Delay(50);
          EULComboLogic._Status = 3;
          break;
        case 3:
          if (Core.Config._Items.Eul.CanBeCasted)
          {
            Core.Config._Items.Eul.UseAbility((Unit) EULComboLogic._Enemy);
            break;
          }
          if (Core.Config._Menu.EULComboMenu.UseLand && (double) Core.Config._QSpell.Cooldown == 0.0)
          {
            Core.Config._QSpell.UseAbility(Core.Config._Hero.Position);
            break;
          }
          if ((double) Core.Config._WSpell.Cooldown == 0.0 && !Core.Config._WSpell.IsInAbilityPhase)
          {
            Core.Config._WSpell.UseAbility(Core.Config._Hero.Position);
            break;
          }
          if (Core.Config._Menu.EULComboMenu.UseRemote && (double) Core.Config._RSpell.Cooldown == 0.0 && !Core.Config._RSpell.IsInAbilityPhase)
          {
            Core.Config._RSpell.UseAbility(Core.Config._Hero.Position);
            break;
          }
          EULComboLogic._Status = 4;
          break;
        case 4:
          if (Core.Config._Menu.EULComboMenu.UseRemote)
          {
            if (EULComboLogic._Enemy.HasModifier("modifier_eul_cyclone"))
              break;
            await Task.Delay(100);
            RemoteBomb remoteBomb = Core.Config._RemoteBombs.FirstOrDefault<RemoteBomb>((Func<RemoteBomb, bool>) (x => x.IsHit(EULComboLogic._Enemy)));
            if (remoteBomb != null)
            {
              Core.Config.Log.Warn("EUL Detonate");
              remoteBomb.Detonate();
              break;
            }
            EULComboLogic._Status = 0;
            break;
          }
          EULComboLogic._Status = 0;
          break;
      }
    }
  }
}
