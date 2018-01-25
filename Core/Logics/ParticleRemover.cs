// Decompiled with JetBrains decompiler
// Type: Core.Logics.ParticleRemover
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using Ensage.SDK.Helpers;
using Ensage.SDK.Renderer.Particle;
using System;
using System.Collections.Generic;
using System.Linq;
using TechiesRage.Models;

namespace Core.Logics
{
  public static class ParticleRemover
  {
    private static readonly Dictionary<string, bool> ChangedDrawings = new Dictionary<string, bool>()
    {
      {
        "LandBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombRange
      },
      {
        "RemoteBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.RemoteBombRange
      },
      {
        "StasisBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombRange
      },
      {
        "StasisBombSubRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombSubRange
      },
      {
        "FrocePath",
        Core.Config._Menu.DrawingsMenu.ForceDrawings.FrocePath
      },
      {
        "FroceRange",
        Core.Config._Menu.DrawingsMenu.ForceDrawings.FroceRange
      }
    };
    private static readonly Dictionary<string, bool> ChangedDrawingsVals = new Dictionary<string, bool>()
    {
      {
        "LandBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombRange
      },
      {
        "RemoteBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.RemoteBombRange
      },
      {
        "StasisBombRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombRange
      },
      {
        "StasisBombSubRange",
        Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombSubRange
      },
      {
        "FrocePath",
        Core.Config._Menu.DrawingsMenu.ForceDrawings.FrocePath
      },
      {
        "FroceRange",
        Core.Config._Menu.DrawingsMenu.ForceDrawings.FroceRange
      }
    };

    public static void OnUpdate()
    {
      if (ParticleRemover.ChangedDrawingsVals["LandBombRange"] != Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombRange)
      {
        ParticleRemover.ChangedDrawingsVals["LandBombRange"] = Core.Config._Menu.DrawingsMenu.BombsDrawings.LandBombRange;
        ParticleRemover.ChangedDrawings["LandBombRange"] = true;
      }
      if (ParticleRemover.ChangedDrawingsVals["RemoteBombRange"] != Core.Config._Menu.DrawingsMenu.BombsDrawings.RemoteBombRange)
      {
        ParticleRemover.ChangedDrawingsVals["RemoteBombRange"] = Core.Config._Menu.DrawingsMenu.BombsDrawings.RemoteBombRange;
        ParticleRemover.ChangedDrawings["RemoteBombRange"] = true;
      }
      if (ParticleRemover.ChangedDrawingsVals["StasisBombRange"] != Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombRange)
      {
        ParticleRemover.ChangedDrawingsVals["StasisBombRange"] = Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombRange;
        ParticleRemover.ChangedDrawings["StasisBombRange"] = true;
      }
      if (ParticleRemover.ChangedDrawingsVals["StasisBombSubRange"] != Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombSubRange)
      {
        ParticleRemover.ChangedDrawingsVals["StasisBombSubRange"] = Core.Config._Menu.DrawingsMenu.BombsDrawings.StasisBombSubRange;
        ParticleRemover.ChangedDrawings["StasisBombSubRange"] = true;
      }
      if (ParticleRemover.ChangedDrawingsVals["FrocePath"] != Core.Config._Menu.DrawingsMenu.ForceDrawings.FrocePath)
      {
        ParticleRemover.ChangedDrawingsVals["FrocePath"] = Core.Config._Menu.DrawingsMenu.ForceDrawings.FrocePath;
        ParticleRemover.ChangedDrawings["FrocePath"] = true;
      }
      if (ParticleRemover.ChangedDrawingsVals["FroceRange"] != Core.Config._Menu.DrawingsMenu.ForceDrawings.FroceRange)
      {
        ParticleRemover.ChangedDrawingsVals["FroceRange"] = Core.Config._Menu.DrawingsMenu.ForceDrawings.FroceRange;
        ParticleRemover.ChangedDrawings["FroceRange"] = true;
      }
      if (ParticleRemover.ChangedDrawings["LandBombRange"])
      {
        if (!ParticleRemover.ChangedDrawingsVals["LandBombRange"])
        {
          foreach (LandBomb landBomb in Core.Config._LandBombs)
          {
            IParticleManager particleManager1 = Core.Config._ParticleManager;
            uint handle = landBomb._Unit.Handle;
            string name1 = handle.ToString();
            if (particleManager1.HasParticle(name1))
            {
              IParticleManager particleManager2 = Core.Config._ParticleManager;
              handle = landBomb._Unit.Handle;
              string name2 = handle.ToString();
              particleManager2.Remove(name2);
            }
          }
        }
        ParticleRemover.ChangedDrawings["LandBombRange"] = false;
      }
      if (ParticleRemover.ChangedDrawings["RemoteBombRange"])
      {
        if (!ParticleRemover.ChangedDrawingsVals["RemoteBombRange"])
        {
          foreach (RemoteBomb remoteBomb in Core.Config._RemoteBombs)
          {
            IParticleManager particleManager1 = Core.Config._ParticleManager;
            uint handle = remoteBomb._Unit.Handle;
            string name1 = handle.ToString();
            if (particleManager1.HasParticle(name1))
            {
              IParticleManager particleManager2 = Core.Config._ParticleManager;
              handle = remoteBomb._Unit.Handle;
              string name2 = handle.ToString();
              particleManager2.Remove(name2);
            }
          }
        }
        ParticleRemover.ChangedDrawings["RemoteBombRange"] = false;
      }
      if (ParticleRemover.ChangedDrawings["StasisBombRange"])
      {
        if (!ParticleRemover.ChangedDrawingsVals["StasisBombRange"])
        {
          foreach (StasisBomb stasisBomb in Core.Config._StasisBombs)
          {
            IParticleManager particleManager1 = Core.Config._ParticleManager;
            uint handle = stasisBomb._Unit.Handle;
            string name1 = handle.ToString();
            if (particleManager1.HasParticle(name1))
            {
              IParticleManager particleManager2 = Core.Config._ParticleManager;
              handle = stasisBomb._Unit.Handle;
              string name2 = handle.ToString();
              particleManager2.Remove(name2);
            }
          }
        }
        ParticleRemover.ChangedDrawings["StasisBombRange"] = false;
      }
      if (ParticleRemover.ChangedDrawings["StasisBombSubRange"])
      {
        if (!ParticleRemover.ChangedDrawingsVals["StasisBombSubRange"])
        {
          foreach (StasisBomb stasisBomb in Core.Config._StasisBombs)
          {
            IParticleManager particleManager1 = Core.Config._ParticleManager;
            string str1 = "st";
            uint handle = stasisBomb._Unit.Handle;
            string str2 = handle.ToString();
            string name1 = str1 + str2;
            if (particleManager1.HasParticle(name1))
            {
              IParticleManager particleManager2 = Core.Config._ParticleManager;
              string str3 = "st";
              handle = stasisBomb._Unit.Handle;
              string str4 = handle.ToString();
              string name2 = str3 + str4;
              particleManager2.Remove(name2);
            }
          }
        }
        ParticleRemover.ChangedDrawings["StasisBombSubRange"] = false;
      }
      if (ParticleRemover.ChangedDrawings["FrocePath"])
      {
        if (!ParticleRemover.ChangedDrawingsVals["FrocePath"])
        {
          foreach (Hero hero in EntityManager<Hero>.Entities.Where<Hero>((Func<Hero, bool>) (x =>
          {
            if (x.Team != Core.Config._Hero.Team)
              return !x.IsIllusion;
            return false;
          })))
          {
            if (Core.Config._ParticleManager.HasParticle(hero.Name + "force"))
              Core.Config._ParticleManager.Remove(hero.Name + "force");
          }
        }
        ParticleRemover.ChangedDrawings["FrocePath"] = false;
      }
      if (!ParticleRemover.ChangedDrawings["FroceRange"])
        return;
      if (!ParticleRemover.ChangedDrawingsVals["FroceRange"] && Core.Config._ParticleManager.HasParticle("TR_ForceRange"))
        Core.Config._ParticleManager.Remove("TR_ForceRange");
      ParticleRemover.ChangedDrawings["FroceRange"] = false;
    }
  }
}
