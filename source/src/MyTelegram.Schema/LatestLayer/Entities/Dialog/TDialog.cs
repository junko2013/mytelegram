﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Chat
/// See <a href="https://corefork.telegram.org/constructor/dialog" />
///</summary>
[TlObject(0xd58a08c6)]
public sealed class TDialog : IDialog
{
    public uint ConstructorId => 0xd58a08c6;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Is the dialog pinned
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Pinned { get; set; }

    ///<summary>
    /// Whether the chat was manually marked as unread
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool UnreadMark { get; set; }

    ///<summary>
    /// Users may also choose to display messages from all topics of a <a href="https://corefork.telegram.org/api/forum">forum</a> as if they were sent to a normal group, using a "View as messages" setting in the local client.  <br>This setting only affects the current account, and is synced to other logged in sessions using the <a href="https://corefork.telegram.org/method/channels.toggleViewForumAsMessages">channels.toggleViewForumAsMessages</a> method; invoking this method will update the value of this flag.
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool ViewForumAsMessages { get; set; }

    ///<summary>
    /// The chat
    /// See <a href="https://corefork.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer Peer { get; set; }

    ///<summary>
    /// The latest message ID
    ///</summary>
    public int TopMessage { get; set; }

    ///<summary>
    /// Position up to which all incoming messages are read.
    ///</summary>
    public int ReadInboxMaxId { get; set; }

    ///<summary>
    /// Position up to which all outgoing messages are read.
    ///</summary>
    public int ReadOutboxMaxId { get; set; }

    ///<summary>
    /// Number of unread messages
    ///</summary>
    public int UnreadCount { get; set; }

    ///<summary>
    /// Number of <a href="https://corefork.telegram.org/api/mentions">unread mentions</a>
    ///</summary>
    public int UnreadMentionsCount { get; set; }

    ///<summary>
    /// Number of unread reactions to messages you sent
    ///</summary>
    public int UnreadReactionsCount { get; set; }

    ///<summary>
    /// Notification settings
    /// See <a href="https://corefork.telegram.org/type/PeerNotifySettings" />
    ///</summary>
    public MyTelegram.Schema.IPeerNotifySettings NotifySettings { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/updates">PTS</a>
    ///</summary>
    public int? Pts { get; set; }

    ///<summary>
    /// Message <a href="https://corefork.telegram.org/api/drafts">draft</a>
    /// See <a href="https://corefork.telegram.org/type/DraftMessage" />
    ///</summary>
    public MyTelegram.Schema.IDraftMessage? Draft { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a>
    ///</summary>
    public int? FolderId { get; set; }

    ///<summary>
    /// Time-to-live of all messages sent in this dialog
    ///</summary>
    public int? TtlPeriod { get; set; }

    public void ComputeFlag()
    {
        if (Pinned) { Flags[2] = true; }
        if (UnreadMark) { Flags[3] = true; }
        if (ViewForumAsMessages) { Flags[6] = true; }
        if (/*Pts != 0 && */Pts.HasValue) { Flags[0] = true; }
        if (Draft != null) { Flags[1] = true; }
        if (/*FolderId != 0 && */FolderId.HasValue) { Flags[4] = true; }
        if (/*TtlPeriod != 0 && */TtlPeriod.HasValue) { Flags[5] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Peer);
        writer.Write(TopMessage);
        writer.Write(ReadInboxMaxId);
        writer.Write(ReadOutboxMaxId);
        writer.Write(UnreadCount);
        writer.Write(UnreadMentionsCount);
        writer.Write(UnreadReactionsCount);
        writer.Write(NotifySettings);
        if (Flags[0]) { writer.Write(Pts.Value); }
        if (Flags[1]) { writer.Write(Draft); }
        if (Flags[4]) { writer.Write(FolderId.Value); }
        if (Flags[5]) { writer.Write(TtlPeriod.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[2]) { Pinned = true; }
        if (Flags[3]) { UnreadMark = true; }
        if (Flags[6]) { ViewForumAsMessages = true; }
        Peer = reader.Read<MyTelegram.Schema.IPeer>();
        TopMessage = reader.ReadInt32();
        ReadInboxMaxId = reader.ReadInt32();
        ReadOutboxMaxId = reader.ReadInt32();
        UnreadCount = reader.ReadInt32();
        UnreadMentionsCount = reader.ReadInt32();
        UnreadReactionsCount = reader.ReadInt32();
        NotifySettings = reader.Read<MyTelegram.Schema.IPeerNotifySettings>();
        if (Flags[0]) { Pts = reader.ReadInt32(); }
        if (Flags[1]) { Draft = reader.Read<MyTelegram.Schema.IDraftMessage>(); }
        if (Flags[4]) { FolderId = reader.ReadInt32(); }
        if (Flags[5]) { TtlPeriod = reader.ReadInt32(); }
    }
}