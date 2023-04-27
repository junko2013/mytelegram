﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
///See <a href="https://core.telegram.org/method/chatlists.getLeaveChatlistSuggestions" />
///</summary>
[TlObject(0xfdbcd714)]
public sealed class RequestGetLeaveChatlistSuggestions : IRequest<TVector<MyTelegram.Schema.IPeer>>
{
    public uint ConstructorId => 0xfdbcd714;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Chatlist.Serialize(bw);
    }

    public void Deserialize(BinaryReader br)
    {
        Chatlist = br.Deserialize<MyTelegram.Schema.IInputChatlist>();
    }
}
