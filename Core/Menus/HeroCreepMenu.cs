// Decompiled with JetBrains decompiler
// Type: Core.Menus.HeroCreepMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu;
using Ensage.SDK.Menu.Items;
using System.ComponentModel;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Hero Creeps")]
  public class HeroCreepMenu
  {
    [Item("Hero Creeps by default")]
    [DefaultValue(true)]
    public bool Creeps { get; set; }

    [Item("Furion by default")]
    [DefaultValue(true)]
    public bool Furion { get; set; }

    [Item("Furion Limit")]
    public Slider<float> FurionLimit { get; set; } = new Slider<float>(2f, 1f, 6f);

    [Item("Enigma by default")]
    [DefaultValue(true)]
    public bool Enigma { get; set; }

    [Item("Enigma Limit")]
    public Slider<float> EnigmaLimit { get; set; } = new Slider<float>(2f, 1f, 6f);

    [Item("Brood by default")]
    [DefaultValue(true)]
    public bool Brood { get; set; }

    [Item("Brood Limit")]
    public Slider<float> BroodLimit { get; set; } = new Slider<float>(2f, 1f, 6f);
  }
}
