﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/storyReactionPublicForward" />
///</summary>
[TlObject(0xbbab2643)]
public sealed class TStoryReactionPublicForward : IStoryReaction
{
    public uint ConstructorId => 0xbbab2643;
    public MyTelegram.Schema.IMessage Message { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Message);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Message = reader.Read<MyTelegram.Schema.IMessage>();
    }
}