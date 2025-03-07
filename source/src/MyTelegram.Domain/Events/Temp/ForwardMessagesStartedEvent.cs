﻿namespace MyTelegram.Domain.Events.Temp;

public class ForwardMessagesStartedEvent(
    RequestInfo requestInfo,
    bool silent,
    bool background,
    bool withMyScore,
    bool dropAuthor,
    bool dropMediaCaptions,
    bool noForwards,
    Peer fromPeer,
    Peer toPeer,
    List<int> messageIds,
    List<long> randomIds,
    int? scheduleDate,
    Peer? sendAs,
    bool forwardFromLinkedChannel)
    : RequestAggregateEvent2<TempAggregate, TempId>(requestInfo)
{
    public bool Silent { get; } = silent;
    public bool Background { get; } = background;
    public bool WithMyScore { get; } = withMyScore;
    public bool DropAuthor { get; } = dropAuthor;
    public bool DropMediaCaptions { get; } = dropMediaCaptions;
    public bool NoForwards { get; } = noForwards;
    public Peer FromPeer { get; } = fromPeer;
    public Peer ToPeer { get; } = toPeer;
    public List<int> MessageIds { get; } = messageIds;
    public List<long> RandomIds { get; } = randomIds;
    public int? ScheduleDate { get; } = scheduleDate;
    public Peer? SendAs { get; } = sendAs;
    public bool ForwardFromLinkedChannel { get; } = forwardFromLinkedChannel;
}