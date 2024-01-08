﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Photos;

///<summary>
/// Returns the list of user photos.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 MAX_ID_INVALID The provided max ID is invalid.
/// 400 MSG_ID_INVALID Invalid message ID provided.
/// 400 USER_ID_INVALID The provided user ID is invalid.
/// See <a href="https://corefork.telegram.org/method/photos.getUserPhotos" />
///</summary>
[TlObject(0x91cd32a8)]
public sealed class RequestGetUserPhotos : IRequest<MyTelegram.Schema.Photos.IPhotos>
{
    public uint ConstructorId => 0x91cd32a8;
    ///<summary>
    /// User ID
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser UserId { get; set; }

    ///<summary>
    /// Number of list elements to be skipped
    ///</summary>
    public int Offset { get; set; }

    ///<summary>
    /// If a positive value was transferred, the method will return only photos with IDs less than the set one. This parameter is often useful when <a href="https://corefork.telegram.org/api/file_reference">refetching file references »</a>, as in conjuction with <code>limit=1</code> and <code>offset=-1</code> the <a href="https://corefork.telegram.org/constructor/photo">photo</a> object with the <code>id</code> specified in <code>max_id</code> can be fetched.
    ///</summary>
    public long MaxId { get; set; }

    ///<summary>
    /// Number of list elements to be returned
    ///</summary>
    public int Limit { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(UserId);
        writer.Write(Offset);
        writer.Write(MaxId);
        writer.Write(Limit);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        UserId = reader.Read<MyTelegram.Schema.IInputUser>();
        Offset = reader.ReadInt32();
        MaxId = reader.ReadInt64();
        Limit = reader.ReadInt32();
    }
}
