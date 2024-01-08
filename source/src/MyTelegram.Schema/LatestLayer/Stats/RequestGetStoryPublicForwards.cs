﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Stats;

///<summary>
/// Obtain forwards of a <a href="https://corefork.telegram.org/api/stories">story</a> as a message to public chats and reposts by public channels.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 PEER_ID_INVALID The provided peer id is invalid.
/// See <a href="https://corefork.telegram.org/method/stats.getStoryPublicForwards" />
///</summary>
[TlObject(0xa6437ef6)]
public sealed class RequestGetStoryPublicForwards : IRequest<MyTelegram.Schema.Stats.IPublicForwards>
{
    public uint ConstructorId => 0xa6437ef6;
    ///<summary>
    /// Peer where the story was originally posted
    /// See <a href="https://corefork.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/stories">Story</a> ID
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// Offset for pagination, from <a href="https://corefork.telegram.org/constructor/stats.publicForwards">stats.PublicForwards</a>.<code>next_offset</code>.
    ///</summary>
    public string Offset { get; set; }

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
        writer.Write(Id);
        writer.Write(Offset);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Peer = reader.Read<MyTelegram.Schema.IInputPeer>();
        Id = reader.ReadInt32();
        Offset = reader.ReadString();
        Limit = reader.ReadInt32();
    }
}
