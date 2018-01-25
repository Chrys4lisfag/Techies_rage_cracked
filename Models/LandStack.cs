// Decompiled with JetBrains decompiler
// Type: TechiesRage.Models.LandStack
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using SharpDX;
using System;
using System.Linq;

namespace TechiesRage.Models
{
  public class LandStack
  {
    public Unit _Unit { get; set; }

    public Guid Id { get; set; }

    public bool MoveForKill { get; set; }

    public bool IsRunToKill { get; set; }

    public LandStack(Unit _StackUnit)
    {
      this._Unit = _StackUnit;
      this.Id = Guid.NewGuid();
      this.MoveForKill = Core.Config._Menu.LandStackMenu.RunKill;
    }

    public string LandsAround()
    {
      return Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 400.0)).ToString();
    }

    public void MoveToStack()
    {
      foreach (LandBomb landBomb in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 450.0)))
        landBomb._Unit.Move(this._Unit.Position + new Vector3(-2f, -2f, 0.0f));
    }

    public string GetDamage()
    {
      return string.Format("{0}", (object) Math.Ceiling((double) ((float) Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 400.0)) * Core.Config._QSpell.GetAbilitySpecialData("damage", Core.Config._QSpell.Level)) * 0.75));
    }
  }
}
