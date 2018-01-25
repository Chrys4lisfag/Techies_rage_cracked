// Decompiled with JetBrains decompiler
// Type: TechiesRage.Models.RemoteBomb
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.Common;
using Ensage.SDK.Extensions;
using Ensage.SDK.Geometry;
using SharpDX;

namespace TechiesRage.Models
{
  public class RemoteBomb
  {
    public Unit _Unit { get; set; }

    public float _Damage { get; set; }

    public bool IsHit(Hero _Enemy)
    {
      if (Core.Config._Menu.Features.UseOldPrediction)
        return !_Enemy.IsRotating() && (double) Prediction.PredictedXYZ((Unit) _Enemy, 300f).Distance2D(this._Unit.Position, false) <= 400.0 && !_Enemy.IsMagicImmune();
      return !_Enemy.IsRotating() && (double) _Enemy.Distance2D(this._Unit.Position) <= 380.0 && !_Enemy.IsMagicImmune();
    }

    public bool IsHit(Vector3 _Pos)
    {
      return (double) _Pos.Distance2D(this._Unit.Position, false) <= 400.0;
    }

    public void Detonate()
    {
      this._Unit.Spellbook.Spell1.UseAbility();
    }
  }
}
