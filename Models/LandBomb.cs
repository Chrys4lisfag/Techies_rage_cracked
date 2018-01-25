// Decompiled with JetBrains decompiler
// Type: TechiesRage.Models.LandBomb
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Extensions;
using Ensage.SDK.Geometry;
using SharpDX;

namespace TechiesRage.Models
{
  public class LandBomb
  {
    public Unit _Unit { get; set; }

    public bool _OnVision { get; set; }

    public float _VisionDate { get; set; }

    public bool IsHit(Hero _Enemy)
    {
      return (double) _Enemy.Distance2D(this._Unit.Position) <= 425.0;
    }

    public bool IsHit(Vector3 _Pos)
    {
      return (double) _Pos.Distance2D(this._Unit.Position, false) <= 425.0;
    }

    public Color DrawingsColor()
    {
      if (this._Unit.NetworkActivity == NetworkActivity.Respawn)
        return Color.DarkRed;
      if (this._OnVision)
        return Color.Orange;
      return Color.Red;
    }
  }
}
