﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stories;

///<summary>
/// Fetch the <a href="https://corefork.telegram.org/api/stories#pinned-or-archived-stories">stories</a> pinned on a peer's profile.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// See <a href="https://corefork.telegram.org/method/stories.getPinnedStories" />
///</summary>
[TlObject(0x5821a5dc)]
public sealed class RequestGetPinnedStories : IRequest<MyTelegram.Schema.Stories.IStories>
{
    public uint ConstructorId => 0x5821a5dc;
    ///<summary>
    /// Peer whose pinned stories should be fetched
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>
    ///</summary>
    public int OffsetId { get; set; }

    ///<summary>
    /// Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Peer);
        writer.Write(OffsetId);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        OffsetId = reader.ReadInt32();
        Limit = reader.ReadInt32();
    }
}
