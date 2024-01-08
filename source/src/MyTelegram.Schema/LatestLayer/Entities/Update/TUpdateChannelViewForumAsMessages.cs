﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Users may also choose to display messages from all topics as if they were sent to a normal group, using a "View as messages" setting in the local client.<br>
/// This setting only affects the current account, and is synced to other logged in sessions using the <a href="https://corefork.telegram.org/method/channels.toggleViewForumAsMessages">channels.toggleViewForumAsMessages</a> method; invoking this method will update the value of the <code>view_forum_as_messages</code> flag of <a href="https://corefork.telegram.org/constructor/channelFull">channelFull</a> or <a href="https://corefork.telegram.org/constructor/dialog">dialog</a> and emit an <a href="https://corefork.telegram.org/constructor/updateChannelViewForumAsMessages">updateChannelViewForumAsMessages</a>.
/// See <a href="https://corefork.telegram.org/constructor/updateChannelViewForumAsMessages" />
///</summary>
[TlObject(0x7b68920)]
public sealed class TUpdateChannelViewForumAsMessages : IUpdate
{
    public uint ConstructorId => 0x7b68920;
    ///<summary>
    /// The forum ID
    ///</summary>
    public long ChannelId { get; set; }

    ///<summary>
    /// The new value of the toggle.
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool Enabled { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(ChannelId);
        writer.Write(Enabled);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        ChannelId = reader.ReadInt64();
        Enabled = reader.Read();
    }
}