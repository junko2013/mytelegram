﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/savedDialog" />
///</summary>
[TlObject(0xbd87cb6c)]
public sealed class TSavedDialog : ISavedDialog
{
    public uint ConstructorId => 0xbd87cb6c;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Pinned { get; set; }
    public MyTelegram.Schema.IPeer Peer { get; set; }
    public int TopMessage { get; set; }

    public void ComputeFlag()
    {
        if (Pinned) { Flags[2] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(TopMessage);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[2]) { Pinned = true; }
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        TopMessage = reader.ReadInt32();
    }
}