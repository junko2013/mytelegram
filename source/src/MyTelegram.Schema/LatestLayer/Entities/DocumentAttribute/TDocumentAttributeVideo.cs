﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Defines a video
/// See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo" />
///</summary>
[TlObject(0xd38ff1c2)]
public sealed class TDocumentAttributeVideo : IDocumentAttribute
{
    public uint ConstructorId => 0xd38ff1c2;
    ///<summary>
    /// Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a>
    ///</summary>
    public BitArray Flags { get; set; } = new BitArray(32);

    ///<summary>
    /// Whether this is a round video
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool RoundMessage { get; set; }

    ///<summary>
    /// Whether the video supports streaming
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool SupportsStreaming { get; set; }

    ///<summary>
    /// Whether the specified document is a video file with no audio tracks (a GIF animation (even as MPEG4), for example)
    /// See <a href="https://corefork.telegram.org/type/true" />
    ///</summary>
    public bool Nosound { get; set; }

    ///<summary>
    /// Duration in seconds
    ///</summary>
    public double Duration { get; set; }

    ///<summary>
    /// Video width
    ///</summary>
    public int W { get; set; }

    ///<summary>
    /// Video height
    ///</summary>
    public int H { get; set; }

    ///<summary>
    /// Number of bytes to preload when preloading videos (particularly <a href="https://corefork.telegram.org/api/stories">video stories</a>).
    ///</summary>
    public int? PreloadPrefixSize { get; set; }

    public void ComputeFlag()
    {
        if (RoundMessage) { Flags[0] = true; }
        if (SupportsStreaming) { Flags[1] = true; }
        if (Nosound) { Flags[3] = true; }
        if (/*PreloadPrefixSize != 0 && */PreloadPrefixSize.HasValue) { Flags[2] = true; }
    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Flags);
        writer.Write(Duration);
        writer.Write(W);
        writer.Write(H);
        if (Flags[2]) { writer.Write(PreloadPrefixSize.Value); }
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Flags = reader.ReadBitArray();
        if (Flags[0]) { RoundMessage = true; }
        if (Flags[1]) { SupportsStreaming = true; }
        if (Flags[3]) { Nosound = true; }
        Duration = reader.ReadDouble();
        W = reader.ReadInt32();
        H = reader.ReadInt32();
        if (Flags[2]) { PreloadPrefixSize = reader.ReadInt32(); }
    }
}