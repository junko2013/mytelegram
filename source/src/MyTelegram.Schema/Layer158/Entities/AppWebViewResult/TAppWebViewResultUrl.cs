﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/appWebViewResultUrl" />
///</summary>
[TlObject(0x3c1b4f0d)]
public sealed class TAppWebViewResultUrl : IAppWebViewResult
{
    public uint ConstructorId => 0x3c1b4f0d;
    public string Url { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Url);
    }

    public void Deserialize(BinaryReader br)
    {
        Url = br.Deserialize<string>();
    }
}