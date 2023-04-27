﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Chatlists;

///<summary>
///See <a href="https://core.telegram.org/method/chatlists.editExportedInvite" />
///</summary>
[TlObject(0x653db63d)]
public sealed class RequestEditExportedInvite : IRequest<MyTelegram.Schema.IExportedChatlistInvite>
{
    public uint ConstructorId => 0x653db63d;
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputChatlist" />
    ///</summary>
    public MyTelegram.Schema.IInputChatlist Chatlist { get; set; }
    public string Slug { get; set; }
    public string? Title { get; set; }
    public TVector<MyTelegram.Schema.IInputPeer>? Peers { get; set; }

    public void ComputeFlag()
    {
        if (Title != null) { Flags[1] = true; }
        if (Peers?.Count > 0) { Flags[2] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Chatlist.Serialize(bw);
        bw.Serialize(Slug);
        if (Flags[1]) { bw.Serialize(Title); }
        if (Flags[2]) { Peers.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        Chatlist = br.Deserialize<MyTelegram.Schema.IInputChatlist>();
        Slug = br.Deserialize<string>();
        if (Flags[1]) { Title = br.Deserialize<string>(); }
        if (Flags[2]) { Peers = br.Deserialize<TVector<MyTelegram.Schema.IInputPeer>>(); }
    }
}
