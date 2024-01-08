﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangePeerColor" />
///</summary>
[TlObject(0x5796e780)]
public sealed class TChannelAdminLogEventActionChangePeerColor : IChannelAdminLogEventAction
{
    public uint ConstructorId => 0x5796e780;
    public MyTelegram.Schema.IPeerColor PrevValue { get; set; }
    public MyTelegram.Schema.IPeerColor NewValue { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(PrevValue);
        writer.Write(NewValue);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        PrevValue = reader.Read<MyTelegram.Schema.IPeerColor>();
        NewValue = reader.Read<MyTelegram.Schema.IPeerColor>();
    }
}