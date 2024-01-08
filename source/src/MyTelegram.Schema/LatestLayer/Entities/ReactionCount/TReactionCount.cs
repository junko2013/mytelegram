﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Reactions
/// See <a href="https://corefork.telegram.org/constructor/reactionCount" />
///</summary>
[TlObject(0xa3d1cb80)]
public sealed class TReactionCount : IReactionCount
{
    public uint ConstructorId => 0xa3d1cb80;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// If set, indicates that the current user also sent this reaction. <br>The integer value indicates when was the reaction added: the bigger the value, the newer the reaction.
    ///</summary>
    public int? ChosenOrder { get; set; }

    ///<summary>
    /// The reaction.
    /// See <a href="https://corefork.telegram.org/type/Reaction" />
    ///</summary>
    public MyTelegram.Schema.IReaction Reaction { get; set; }

    ///<summary>
    /// Number of users that reacted with this emoji.
    ///</summary>
    public int Count { get; set; }

    public void ComputeFlag()
    {
        if (/*ChosenOrder != 0 && */ChosenOrder.HasValue) { Flags[0] = true; }

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        if (Flags[0]) { writer.Write(ChosenOrder.Value); }
        writer.Write(Reaction);
        writer.Write(Count);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { ChosenOrder = reader.ReadInt32(); }
        Reaction = reader.Read<MyTelegram.Schema.IReaction>();
        Count = reader.ReadInt32();
    }
}