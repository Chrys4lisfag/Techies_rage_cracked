// Decompiled with JetBrains decompiler
// Type: Core.Helpers.HUDHelper
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.Common;
using SharpDX;
using System.Collections.Generic;

namespace Core.Helpers
{
  public static class HUDHelper
  {
    private static Dictionary<ClassId, Vector2> _Poses = new Dictionary<ClassId, Vector2>();
    private static Dictionary<ClassId, Vector2> _TopPanelPoses = new Dictionary<ClassId, Vector2>();
    public static float LandBombWidth = HUDInfo.GetHPBarSizeX((Unit) null);

    public static Vector2 GetHPbarPosition(Unit _Unit)
    {
      if (HUDHelper._Poses.ContainsKey(_Unit.ClassId))
        return Drawing.WorldToScreen(_Unit.Position) + HUDHelper._Poses[_Unit.ClassId];
      Vector2 vector2 = HUDInfo.GetHPbarPosition(_Unit) - Drawing.WorldToScreen(_Unit.Position);
      HUDHelper._Poses.Add(_Unit.ClassId, vector2);
      return vector2;
    }

    public static Vector2 GetTopPanelPosition(Hero _Unit)
    {
      if (HUDHelper._TopPanelPoses.ContainsKey(_Unit.ClassId))
        return HUDHelper._TopPanelPoses[_Unit.ClassId];
      Vector2 vector2 = HUDInfo.GetTopPanelPosition(_Unit) + new Vector2(0.0f, (float) HUDInfo.GetTopPanelSizeX(_Unit));
      HUDHelper._TopPanelPoses.Add(_Unit.ClassId, vector2);
      return vector2;
    }
  }
}
