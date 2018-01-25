// Decompiled with JetBrains decompiler
// Type: Core.Menus.DamageHelpersMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Damage Helpers")]
  public class DamageHelpersMenu
  {
    [Item("Use Veil")]
    [DefaultValue(true)]
    public bool UseVeil { get; set; }

    [Item("Use Dagon")]
    [DefaultValue(true)]
    public bool UseDagon { get; set; }

    [Item("Use Etherial")]
    [DefaultValue(true)]
    public bool UseEtherial { get; set; }
  }
}
