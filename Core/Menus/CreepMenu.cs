// Decompiled with JetBrains decompiler
// Type: Core.Menus.CreepMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Creeps")]
  public class CreepMenu
  {
    [Item("Necro by default")]
    [DefaultValue(false)]
    public bool Necro { get; set; }

    [Item("Necro Limit")]
    public Slider<float> NecroLimit { get; set; } = new Slider<float>(2f, 1f, 2f);

    [Item("Manta by default")]
    [DefaultValue(false)]
    public bool Manta { get; set; }

    [Item("Manta Limit")]
    public Slider<float> MantaLimit { get; set; } = new Slider<float>(2f, 1f, 4f);

    [Item("Creeps by default")]
    [DefaultValue(false)]
    public bool Creeps { get; set; }

    [Item("Creeps Limit")]
    public Slider<float> CreepsLimit { get; set; } = new Slider<float>(4f, 1f, 8f);
  }
}
