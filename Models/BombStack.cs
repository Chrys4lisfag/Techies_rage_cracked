// Decompiled with JetBrains decompiler
// Type: TechiesRage.Models.BombStack
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
  public class BombStack
  {
    public Unit _Unit { get; set; }

    public int DetonateOnHeroes { get; set; } = 1;

    public Guid Id { get; set; }

    public bool[] _Disabler { get; set; } = new bool[5];

    public bool Necro { get; set; }

    public bool Manta { get; set; }

    public bool Creeps { get; set; }

    public bool HeroCreeps { get; set; }

    public BombStack(Unit _StackUnit)
    {
      this._Unit = _StackUnit;
      this.Id = Guid.NewGuid();
    }

    public string RemotesAround()
    {
      return Core.Config._RemoteBombs.Count<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 100.0)).ToString();
    }

    public string LandsAround()
    {
      return Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 400.0)).ToString();
    }

    public void Detonate1()
    {
      if (!Core.Config._Menu.Features.DetonatekeyDown)
        return;
      foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) this._Unit.Distance2D(x._Unit, false) <= 100.0)).ToArray<RemoteBomb>())
      {
        Core.Config.Log.Warn(nameof (Detonate1));
        remoteBomb.Detonate();
      }
    }

    public void Detonate2()
    {
      if (!Core.Config._Menu.Features.DetonatekeyDown)
        return;
      foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) this._Unit.Distance2D(x._Unit, false) <= 100.0)).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime)).Take<RemoteBomb>(2))
      {
        Core.Config.Log.Warn(nameof (Detonate2));
        remoteBomb.Detonate();
      }
    }

    public void Detonate3()
    {
      if (!Core.Config._Menu.Features.DetonatekeyDown)
        return;
      foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) this._Unit.Distance2D(x._Unit, false) <= 100.0)).OrderBy<RemoteBomb, float>((Func<RemoteBomb, float>) (x => x._Unit.CreateTime)).Take<RemoteBomb>(1))
      {
        Core.Config.Log.Warn(nameof (Detonate3));
        remoteBomb.Detonate();
      }
    }

    public void MoveToStack()
    {
      foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 100.0)))
        remoteBomb._Unit.Move(this._Unit.Position + new Vector3(-2f, 2f, 0.0f));
    }

    public void MoveLandToStack()
    {
      foreach (LandBomb landBomb in Core.Config._LandBombs.Where<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 450.0)))
        landBomb._Unit.Move(this._Unit.Position + new Vector3(-1f, 2f, 0.0f));
    }

    public string GetDamage()
    {
      float num1 = 0.0f;
      foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs.Where<RemoteBomb>((Func<RemoteBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 100.0)))
        num1 += remoteBomb._Damage;
      float num2 = (float) Core.Config._LandBombs.Count<LandBomb>((Func<LandBomb, bool>) (x => (double) x._Unit.Distance2D(this._Unit, false) <= 400.0)) * Core.Config._QSpell.GetAbilitySpecialData("damage", Core.Config._QSpell.Level);
      return string.Format("{0} / {1}", (object) Math.Ceiling((double) num1 * 0.75), (object) Math.Ceiling((double) num2 * 0.75));
    }
  }
}
