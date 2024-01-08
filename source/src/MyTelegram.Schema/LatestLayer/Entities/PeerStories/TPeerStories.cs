﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// <a href="https://corefork.telegram.org/api/stories">Stories</a> associated to a peer
/// See <a href="https://corefork.telegram.org/constructor/peerStories" />
///</summary>
[TlObject(0x9a35e999)]
public sealed class TPeerStories : IPeerStories
{
    public uint ConstructorId => 0x9a35e999;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// The peer
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }

    ///<summary>
    /// If set, contains the ID of the maximum read story
    ///</summary>
    public int? MaxReadId { get; set; }

    ///<summary>
    /// Stories
    ///</summary>
    public TVector<MyTelegram.Schema.IStoryItem> Stories { get; set; }

    public void ComputeFlag()
    {
        if (/*MaxReadId != 0 && */MaxReadId.HasValue) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        if (Flags[0]) { writer.Write(MaxReadId.Value); }
        writer.Write(Stories);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        if (Flags[0]) { MaxReadId = reader.ReadInt32(); }
        Stories = reader.Read<TVector<MyTelegram.Schema.IStoryItem>>();
    }
}