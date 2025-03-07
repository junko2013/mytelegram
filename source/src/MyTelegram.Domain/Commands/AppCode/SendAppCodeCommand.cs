﻿namespace MyTelegram.Domain.Commands.AppCode;

public class SendAppCodeCommand(
    AppCodeId aggregateId,
    RequestInfo requestInfo,
    long userId,
    string phoneNumber,
    string code,
    string phoneCodeHash,
    int expire,
    long creationTime)
    : RequestCommand2<AppCodeAggregate, AppCodeId, IExecutionResult>(aggregateId, requestInfo)
{
    public string Code { get; } = code;
    public long CreationTime { get; } = creationTime;
    public int Expire { get; } = expire;

    public string PhoneCodeHash { get; } = phoneCodeHash;
    public long UserId { get; } = userId;
    public string PhoneNumber { get; } = phoneNumber;
}
