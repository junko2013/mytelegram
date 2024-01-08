﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Convert a <a href="https://corefork.telegram.org/api/channel">supergroup</a> to a <a href="https://corefork.telegram.org/api/channel">gigagroup</a>, when requested by <a href="https://corefork.telegram.org/api/config#channel-suggestions">channel suggestions</a>.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 CHANNEL_ID_INVALID The specified supergroup ID is invalid.
/// 400 CHANNEL_INVALID The provided channel is invalid.
/// 400 CHAT_ADMIN_REQUIRED You must be an admin in this chat to do this.
/// 403 CHAT_WRITE_FORBIDDEN You can't write in this chat.
/// 400 FORUM_ENABLED You can't execute the specified action because the group is a <a href="https://corefork.telegram.org/api/forum">forum</a>, disable forum functionality to continue.
/// 400 PARTICIPANTS_TOO_FEW Not enough participants.
/// See <a href="https://corefork.telegram.org/method/channels.convertToGigagroup" />
///</summary>
[TlObject(0xb290c69)]
public sealed class RequestConvertToGigagroup : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0xb290c69;
    ///<summary>
    /// The <a href="https://corefork.telegram.org/api/channel">supergroup</a> to convert
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
    }
}
