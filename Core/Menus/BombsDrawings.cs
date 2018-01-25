// Decompiled with JetBrains decompiler
// Type: Core.Menus.BombsDrawings
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Bomb Drawings")]
  public class BombsDrawings
  {
    [Item("Land Range")]
    [DefaultValue(true)]
    public bool LandBombRange { get; set; }

    [Item("Land Timer")]
    [DefaultValue(true)]
    public bool LandBombTimer { get; set; }

    [Item("Stasis Range")]
    [DefaultValue(true)]
    public bool StasisBombRange { get; set; }

    [Item("Stasis Stun Range")]
    [DefaultValue(true)]
    public bool StasisBombSubRange { get; set; }

    [Item("Remote Range")]
    [DefaultValue(true)]
    public bool RemoteBombRange { get; set; }

    [Item("Force Pos")]
    [DefaultValue(true)]
    public bool ForcePos { get; set; }
  }
}
