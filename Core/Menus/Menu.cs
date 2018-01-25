// Decompiled with JetBrains decompiler
// Type: Core.Menus.Menu
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage.SDK.Menu.Attributes;

namespace Core.Menus
{
  [Ensage.SDK.Menu.Menu("Techies Rage")]
  [TextureResource("TR_Logo", "Images.IngameLogo.png")]
  public class Menu
  {
    public Menu()
    {
      this.DrawingsMenu = new DrawingsMenu();
      this.LandStackMenu = new LandStackMenu();
      this.DamageHelpersMenu = new DamageHelpersMenu();
      this.DetonationMenu = new DetonationMenu();
      this.EULComboMenu = new EULComboMenu();
      this.Features = new FeaturesMenu();
    }

    [Ensage.SDK.Menu.Menu("Drawings")]
    public DrawingsMenu DrawingsMenu { get; set; }

    [Ensage.SDK.Menu.Menu("Land Stacks")]
    public LandStackMenu LandStackMenu { get; set; }

    [Ensage.SDK.Menu.Menu("Damage Helpers")]
    public DamageHelpersMenu DamageHelpersMenu { get; set; }

    [Ensage.SDK.Menu.Menu("Detonation")]
    public DetonationMenu DetonationMenu { get; set; }

    [Ensage.SDK.Menu.Menu("EUL Combo")]
    public EULComboMenu EULComboMenu { get; set; }

    [Ensage.SDK.Menu.Menu("Features")]
    public FeaturesMenu Features { get; set; }
  }
}
