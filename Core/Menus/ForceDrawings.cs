// Decompiled with JetBrains decompiler
// Type: Core.Menus.ForceDrawings
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Force Drawings")]
  public class ForceDrawings
  {
    [Item("Draw force path")]
    [DefaultValue(true)]
    public bool FrocePath { get; set; }

    [Item("Draw force Range")]
    [DefaultValue(true)]
    public bool FroceRange { get; set; }
  }
}
