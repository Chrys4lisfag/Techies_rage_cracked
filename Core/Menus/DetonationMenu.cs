// Decompiled with JetBrains decompiler
// Type: Core.Menus.DetonationMenu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Detonation")]
  public class DetonationMenu
  {
    public DetonationMenu()
    {
      this.CreepMenu = new CreepMenu();
      this.HeroCreepMenu = new HeroCreepMenu();
    }

    [Ensage.SDK.Menu.Menu("Creeps")]
    public CreepMenu CreepMenu { get; set; }

    [Ensage.SDK.Menu.Menu("Hero Creeps")]
    public HeroCreepMenu HeroCreepMenu { get; set; }
  }
}
