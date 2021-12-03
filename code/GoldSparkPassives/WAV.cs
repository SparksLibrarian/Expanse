// Decompiled with JetBrains decompiler
// Type: GoldSparkPassives.WAV
// Assembly: GoldSparkPassives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 831531F7-4DAD-418E-B6A8-3BE44D34C942
// Assembly location: C:\Users\wilga\Desktop\Library of Ruina\Expanse\Assemblies\GoldSparkPassives.dll

using System.IO;

namespace GoldSparkPassives
{
  public class WAV
  {
    private static float bytesToFloat(byte firstByte, byte secondByte) => (float) (short) ((int) secondByte << 8 | (int) firstByte) / 32768f;

    private static int bytesToInt(byte[] bytes, int offset = 0)
    {
      int num = 0;
      for (int index = 0; index < 4; ++index)
        num |= (int) bytes[offset + index] << index * 8;
      return num;
    }

    private static byte[] GetBytes(string filename) => File.ReadAllBytes(filename);

    public float[] LeftChannel { get; internal set; }

    public float[] RightChannel { get; internal set; }

    public int ChannelCount { get; internal set; }

    public int SampleCount { get; internal set; }

    public int Frequency { get; internal set; }

    public WAV(string filename)
      : this(WAV.GetBytes(filename))
    {
    }

    public WAV(byte[] wav)
    {
      this.ChannelCount = (int) wav[22];
      this.Frequency = WAV.bytesToInt(wav, 24);
      int index1;
      int index2;
      int num;
      for (index1 = 12; wav[index1] != (byte) 100 || wav[index1 + 1] != (byte) 97 || wav[index1 + 2] != (byte) 116 || wav[index1 + 3] != (byte) 97; index1 = index2 + (4 + num))
      {
        index2 = index1 + 4;
        num = (int) wav[index2] + (int) wav[index2 + 1] * 256 + (int) wav[index2 + 2] * 65536 + (int) wav[index2 + 3] * 16777216;
      }
      int index3 = index1 + 8;
      this.SampleCount = (wav.Length - index3) / 2;
      if (this.ChannelCount == 2)
        this.SampleCount /= 2;
      this.LeftChannel = new float[this.SampleCount];
      this.RightChannel = this.ChannelCount != 2 ? (float[]) null : new float[this.SampleCount];
      int index4 = 0;
      while (index3 < wav.Length)
      {
        this.LeftChannel[index4] = WAV.bytesToFloat(wav[index3], wav[index3 + 1]);
        index3 += 2;
        if (this.ChannelCount == 2)
        {
          this.RightChannel[index4] = WAV.bytesToFloat(wav[index3], wav[index3 + 1]);
          index3 += 2;
        }
        ++index4;
      }
    }

    public override string ToString() => string.Format("[WAV: LeftChannel={0}, RightChannel={1}, ChannelCount={2}, SampleCount={3}, Frequency={4}]", (object) this.LeftChannel, (object) this.RightChannel, (object) this.ChannelCount, (object) this.SampleCount, (object) this.Frequency);
  }
}
