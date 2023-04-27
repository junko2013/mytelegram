﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.requestAppWebView" />
///</summary>
[TlObject(0x8c5a3b3c)]
public sealed class RequestRequestAppWebView : IRequest<MyTelegram.Schema.IAppWebViewResult>
{
    public uint ConstructorId => 0x8c5a3b3c;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool WriteAllowed { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputBotApp" />
    ///</summary>
    public MyTelegram.Schema.IInputBotApp App { get; set; }
    public string? StartParam { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/DataJSON" />
    ///</summary>
    public MyTelegram.Schema.IDataJSON? ThemeParams { get; set; }
    public string Platform { get; set; }

    public void ComputeFlag()
    {
        if (WriteAllowed) { Flags[0] = true; }
        if (StartParam != null) { Flags[1] = true; }
        if (ThemeParams != null) { Flags[2] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Peer.Serialize(bw);
        App.Serialize(bw);
        if (Flags[1]) { bw.Serialize(StartParam); }
        if (Flags[2]) { ThemeParams.Serialize(bw); }
        bw.Serialize(Platform);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { WriteAllowed = true; }
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        App = br.Deserialize<MyTelegram.Schema.IInputBotApp>();
        if (Flags[1]) { StartParam = br.Deserialize<string>(); }
        if (Flags[2]) { ThemeParams = br.Deserialize<MyTelegram.Schema.IDataJSON>(); }
        Platform = br.Deserialize<string>();
    }
}
