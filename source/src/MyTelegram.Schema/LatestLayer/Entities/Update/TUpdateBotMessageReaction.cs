﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/updateBotMessageReaction" />
///</summary>
[TlObject(0xac21d3ce)]
public sealed class TUpdateBotMessageReaction : IUpdate
{
    public uint ConstructorId => 0xac21d3ce;
    public MyTelegram.Schema.IPeer Peer { get; set; }
    public int MsgId { get; set; }
    public int Date { get; set; }
    public MyTelegram.Schema.IPeer Actor { get; set; }
    public TVector<MyTelegram.Schema.IReaction> OldReactions { get; set; }
    public TVector<MyTelegram.Schema.IReaction> NewReactions { get; set; }
    public int Qts { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(MsgId);
        writer.Write(Date);
        writer.Write(Actor);
        writer.Write(OldReactions);
        writer.Write(NewReactions);
        writer.Write(Qts);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        MsgId = reader.ReadInt32();
        Date = reader.ReadInt32();
        Actor = reader.Read<MyTelegram.Schema.IPeer>();
        OldReactions = reader.Read<TVector<MyTelegram.Schema.IReaction>>();
        NewReactions = reader.Read<TVector<MyTelegram.Schema.IReaction>>();
        Qts = reader.ReadInt32();
    }
}