﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Describes a <a href="https://corefork.telegram.org/api/links#temporary-profile-links">temporary profile link</a>.
/// See <a href="https://corefork.telegram.org/constructor/exportedContactToken" />
///</summary>
[TlObject(0x41bf109b)]
public sealed class TExportedContactToken : IExportedContactToken
{
    public uint ConstructorId => 0x41bf109b;
    ///<summary>
    /// The <a href="https://corefork.telegram.org/api/links#temporary-profile-links">temporary profile link</a>.
    ///</summary>
    public string Url { get; set; }

    ///<summary>
    /// Its expiration date
    ///</summary>
    public int Expires { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Url);
        writer.Write(Expires);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Url = reader.ReadString();
        Expires = reader.ReadInt32();
    }
}