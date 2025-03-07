﻿namespace MyTelegram.Domain.Commands.Channel;

public class CreateChannelCommand(
    ChannelId aggregateId,
    RequestInfo requestInfo,
    long channelId,
    long creatorId,
    string title,
    bool broadcast,
    bool megaGroup,
    string? about,
    string? address,
    long accessHash,
    int date,
    long randomId,
    string messageActionData,
    int? ttlPeriod,
    bool migratedFromChat,
    long? migrateFromChatId,
    int? migratedMaxId,
    long? photoId,
    bool autoCreateFromChat = false
    )
    : RequestCommand2<ChannelAggregate, ChannelId, IExecutionResult>(aggregateId, requestInfo)
{
    public string? About { get; } = about;
    public long AccessHash { get; } = accessHash;
    public string? Address { get; } = address;

    public bool Broadcast { get; } = broadcast;
    public long ChannelId { get; } = channelId;
    public long CreatorId { get; } = creatorId;
    public int Date { get; } = date;
    public bool MegaGroup { get; } = megaGroup;
    public string MessageActionData { get; } = messageActionData;
    public int? TtlPeriod { get; } = ttlPeriod;
    public bool MigratedFromChat { get; } = migratedFromChat;
    public long? MigrateFromChatId { get; } = migrateFromChatId;
    public int? MigratedMaxId { get; } = migratedMaxId;
    public long? PhotoId { get; } = photoId;
    public bool AutoCreateFromChat { get; } = autoCreateFromChat;
    public long RandomId { get; } = randomId;
    public string Title { get; } = title;
}
