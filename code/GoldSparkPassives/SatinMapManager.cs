// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.SatinMapManager
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using CustomMapUtility;

namespace GoldSparkPassives
{
  public class SatinMapManager : CustomMapManager
  {
    protected internal override string[] CustomBGMs => new string[1]
    {
      "Shiva.mp3"
    };

    public override void InitializeMap()
    {
      base.InitializeMap();
      this.sephirahType = SephirahType.None;
    }
  }
}
