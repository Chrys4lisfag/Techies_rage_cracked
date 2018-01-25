// Decompiled with JetBrains decompiler
// Type: Core.Sleeper
// Assembly: Techies Rage, Version=1.3.3.0, Culture=neutral, PublicKeyToken=null
// MVID: E777AB4F-CAF5-4795-BCC2-C0567A6BAEE0
// Assembly location: C:\Users\koval\Desktop\Techies Rage.dll

using Ensage;
using System.Collections.Generic;

namespace Core
{
  public static class Sleeper
  {
    private static Dictionary<string, float> _IsSleepTimes = new Dictionary<string, float>();

    public static void Sleep(string Name, float Delay)
    {
      if (Sleeper._IsSleepTimes.ContainsKey(Name))
        Sleeper._IsSleepTimes[Name] = Game.RawGameTime + Delay;
      else
        Sleeper._IsSleepTimes.Add(Name, Game.RawGameTime + Delay);
    }

    public static bool IsSleep(string Name)
    {
      if (Sleeper._IsSleepTimes.ContainsKey(Name))
        return (double) Game.RawGameTime < (double) Sleeper._IsSleepTimes[Name];
      return false;
    }
  }
}
