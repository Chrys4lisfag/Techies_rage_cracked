// Decompiled with JetBrains decompiler
// Type: Core.Helpers.DagonManager
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Abilities;

namespace Core.Helpers
{
  public static class DagonManager
  {
    public static Item GetDagon()
    {
      if (Core.Config._Items.Dagon1 != null)
        return (Item) ((BaseAbility) Core.Config._Items.Dagon1);
      if (Core.Config._Items.Dagon2 != null)
        return (Item) ((BaseAbility) Core.Config._Items.Dagon2);
      if (Core.Config._Items.Dagon3 != null)
        return (Item) ((BaseAbility) Core.Config._Items.Dagon3);
      if (Core.Config._Items.Dagon4 != null)
        return (Item) ((BaseAbility) Core.Config._Items.Dagon4);
      if (Core.Config._Items.Dagon5 != null)
        return (Item) ((BaseAbility) Core.Config._Items.Dagon5);
      return (Item) null;
    }
  }
}
