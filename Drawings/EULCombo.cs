// Decompiled with JetBrains decompiler
// Type: TechiesRage.Drawings.EULCombo
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Renderer.Particle;
using SharpDX;
using Core.Logics;

namespace TechiesRage.Drawings
{
  public static class EULCombo
  {
    public static void OnUpdate()
    {
      if (EULComboLogic._Status == 1)
      {
        Core.Config._ParticleManager.DrawCircle(EULComboLogic._JPos, nameof (EULCombo), 400f, Color.OrangeRed);
        Core.Config._ParticleManager.DrawTargetLine(Core.Config._Hero, "EULCombo3", EULComboLogic._Enemy.Position, new Color?(Color.OrangeRed));
        Core.Config._ParticleManager.AddOrUpdate(Core.Config._Hero, "TR_EULComboZone1", "materials/ensage_ui/particles/alert_range.vpcf", ParticleAttachment.AbsOrigin, RestartType.None, 0, EULComboLogic._JPos, 1, Color.Orange, 2, new Vector3(200f, byte.MaxValue, 200f));
      }
      else
      {
        if (!Core.Config._ParticleManager.HasParticle(nameof (EULCombo)))
          return;
        Core.Config._ParticleManager.Remove(nameof (EULCombo));
        Core.Config._ParticleManager.Remove("TR_EULComboZone1");
        Core.Config._ParticleManager.Remove("EULCombo3");
      }
    }
  }
}
