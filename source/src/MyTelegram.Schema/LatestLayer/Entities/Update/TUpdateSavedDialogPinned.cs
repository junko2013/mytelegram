﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/updateSavedDialogPinned" />
///</summary>
[TlObject(0xaeaf9e74)]
public sealed class TUpdateSavedDialogPinned : IUpdate
{
    public uint ConstructorId => 0xaeaf9e74;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Pinned { get; set; }
    public MyTelegram.Schema.IDialogPeer Peer { get; set; }

    public void ComputeFlag()
    {
        if (Pinned) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { Pinned = true; }
        Peer = reader.Read<MyTelegram.Schema.IDialogPeer>();
    }
}