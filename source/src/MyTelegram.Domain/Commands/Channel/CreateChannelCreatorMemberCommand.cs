﻿namespace MyTelegram.Domain.Commands.Channel;

public class
    CreateChannelCreatorMemberCommand(
        ChannelMemberId aggregateId,
        RequestInfo requestInfo,
        long channelId,
        long userId,
        int date)
    : RequestCommand2<ChannelMemberAggregate, ChannelMemberId, IExecutionResult>(aggregateId, requestInfo)
{
    public long ChannelId { get; } = channelId;

    //public int InviterId { get; }
    public int Date { get; } = date;
    public long UserId { get; } = userId;
}
