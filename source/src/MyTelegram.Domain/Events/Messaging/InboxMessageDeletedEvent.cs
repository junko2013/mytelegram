﻿namespace MyTelegram.Domain.Events.Messaging;

public class InboxMessageDeletedEvent(
    RequestInfo requestInfo,
    long ownerPeerId,
    int messageId,
    int senderMessageId)
    : AggregateEvent<MessageAggregate, MessageId>, IHasRequestInfo
{
    public int MessageId { get; } = messageId;
    public int SenderMessageId { get; } = senderMessageId;
    public RequestInfo RequestInfo { get; } = requestInfo;
    public long OwnerPeerId { get; } = ownerPeerId;
}
