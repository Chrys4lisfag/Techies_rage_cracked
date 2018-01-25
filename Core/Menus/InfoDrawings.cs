// Decompiled with JetBrains decompiler
// Type: Core.Menus.InfoDrawings
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Info Drawings")]
  public class InfoDrawings
  {
    [Item("Info on Hero")]
    [DefaultValue(true)]
    public bool InfoHero { get; set; }

    [Item("Info top panel")]
    [DefaultValue(true)]
    public bool InfoTop { get; set; }

    [Item("Top X")]
    public Slider<float> TopX { get; set; } = new Slider<float>(0.0f, -600f, 600f);

    [Item("Top Y")]
    public Slider<float> TopY { get; set; } = new Slider<float>(0.0f, -600f, 600f);
  }
}
