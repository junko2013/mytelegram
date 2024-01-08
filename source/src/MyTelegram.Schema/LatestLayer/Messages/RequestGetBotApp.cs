﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
/// Obtain information about a <a href="https://corefork.telegram.org/api/bots/webapps#named-mini-apps">named Mini App</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 BOT_APP_INVALID The specified bot app is invalid.
/// See <a href="https://corefork.telegram.org/method/messages.getBotApp" />
///</summary>
[TlObject(0x34fdc5c3)]
public sealed class RequestGetBotApp : IRequest<MyTelegram.Schema.Messages.IBotApp>
{
    public uint ConstructorId => 0x34fdc5c3;
    ///<summary>
    /// Bot app information obtained from a <a href="https://corefork.telegram.org/api/links#named-mini-app-links">named Mini App deep link »</a>.
    /// See <a href="https://corefork.telegram.org/type/InputBotApp" />
    ///</summary>
    public MyTelegram.Schema.IInputBotApp App { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a>
    ///</summary>
    public long Hash { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(App);
        writer.Write(Hash);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        App = reader.Read<MyTelegram.Schema.IInputBotApp>();
        Hash = reader.ReadInt64();
    }
}
