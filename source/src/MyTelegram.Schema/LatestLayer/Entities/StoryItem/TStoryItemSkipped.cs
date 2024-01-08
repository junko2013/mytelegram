﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Represents an active story, whose full information was omitted for space and performance reasons; use <a href="https://corefork.telegram.org/method/stories.getStoriesByID">stories.getStoriesByID</a> to fetch full info about the skipped story when and if needed.
/// See <a href="https://corefork.telegram.org/constructor/storyItemSkipped" />
///</summary>
[TlObject(0xffadc913)]
public sealed class TStoryItemSkipped : IStoryItem
{
    public uint ConstructorId => 0xffadc913;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether this story can only be viewed by <a href="https://corefork.telegram.org/api/privacy">our close friends, see here »</a> for more info
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool CloseFriends { get; set; }

    ///<summary>
    /// Story ID
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// When was the story posted.
    ///</summary>
    public int Date { get; set; }

    ///<summary>
    /// When does the story expire.
    ///</summary>
    public int ExpireDate { get; set; }

    public void ComputeFlag()
    {
        if (CloseFriends) { Flags[8] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Id);
        writer.Write(Date);
        writer.Write(ExpireDate);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[8]) { CloseFriends = true; }
        Id = reader.ReadInt32();
        Date = reader.ReadInt32();
        ExpireDate = reader.ReadInt32();
    }
}