﻿namespace MyTelegram.ReadModel.Impl;
public class ChannelReadModel : IChannelReadModel,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelCreatedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, IncrementParticipantCountEvent>,
    //IAmReadModelFor<MessageSaga, MessageSagaId, SendChannelMessageSuccessEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, StartSendChannelMessageEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelTitleEditedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelAboutEditedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, SetChannelPtsEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelDefaultBannedRightsEditedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, SlowModeChangedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelAdminRightsEditedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelPhotoEditedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelUserNameChangedEvent>,
    IAmReadModelFor<ChannelMemberAggregate, ChannelMemberId, ChannelMemberLeftEvent>,
    IAmReadModelFor<ChannelMemberAggregate, ChannelMemberId, ChannelMemberBannedRightsChangedEvent>,
    IAmReadModelFor<ChannelMemberAggregate, ChannelMemberId, ChannelMemberJoinedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, DiscussionGroupUpdatedEvent>,
    IAmReadModelFor<ChannelAggregate, ChannelId, ChannelColorUpdatedEvent>,
    IAmReadModelFor<ChannelAggregate,ChannelId, LinkedChannelChangedEvent>,

    IAmReadModelFor<DeleteChannelMessagesSaga,DeleteChannelMessagesSagaId, DeleteChannelMessagesCompletedEvent>,
    IAmReadModelFor<DeleteChannelMessagesSaga,DeleteChannelMessagesSagaId, DeleteChannelHistoryCompletedEvent>,
    IAmReadModelFor<DeleteReplyMessagesSaga, DeleteReplyMessagesSagaId, DeleteReplyMessagesCompletedEvent>
    //IAmReadModelFor<ChannelAggregate, ChannelId, ChannelAvailableReactionsChangedEvent>

{
    public string? About { get; private set; }
    public long AccessHash { get; private set; }
    public string? Address { get; private set; }
    //public ChatAdminRights AdminRights { get; private set; }
    public virtual List<ChatAdmin> AdminList { get; protected set; } = new();

    public bool Broadcast { get; private set; }
    public long ChannelId { get; private set; }
    public long CreatorId { get; private set; }
    public int Date { get; private set; }
    public virtual ChatBannedRights? DefaultBannedRights { get; protected set; }
    public virtual string Id { get; private set; } = null!;
    public int LastSendDate { get; private set; }
    public long LastSenderPeerId { get; private set; }
    public bool MegaGroup { get; private set; }
    public int? ParticipantsCount { get; private set; }
    //public byte[]? Photo { get; private set; }
    public int Pts { get; private set; }
    public bool Signatures { get; private set; }
    public bool SlowModeEnabled { get; private set; }

    public string Title { get; private set; } = null!;
    //public string Link { get; private set; }
    //public string TopMessageBoxId { get; private set; }

    public int TopMessageId { get; private set; }
    public string? UserName { get; private set; }
    public bool Verified { get; private set; }
    public long? LinkedChatId { get; private set; }

    public bool Forum { get; private set; }
    public int? TtlPeriod { get; private set; }
    public long? PhotoId { get; private set; }
    public bool NoForwards { get; private set; }
    public PeerColor? Color { get; private set; }
    public PeerColor? ProfileColor { get; private set; }
    public long? BackgroundEmojiId { get; private set; }
    public int? Level { get; private set; }
    public bool HasLink { get; private set; }

    //public ReactionType ReactionType { get; private set; }
    //public bool AllowCustomReaction { get; private set; }
    //public List<string>? AvailableReactions { get; private set; }
    public virtual long? Version { get; set; }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelAboutEditedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        About = domainEvent.AggregateEvent.About;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelAdminRightsEditedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.IsNewAdmin)
        {
            AdminList.Add(new ChatAdmin(domainEvent.AggregateEvent.PromotedBy, domainEvent.AggregateEvent.CanEdit, domainEvent.AggregateEvent.UserId, domainEvent.AggregateEvent.AdminRights, domainEvent.AggregateEvent.Rank));
        }
        else
        {
            var admin = AdminList.FirstOrDefault(p => p.UserId == domainEvent.AggregateEvent.UserId);
            if (admin != null)
            {
                admin.SetAdminRights(domainEvent.AggregateEvent.AdminRights);
            }
        }

        if (domainEvent.AggregateEvent.RemoveAdminFromList)
        {
            AdminList.RemoveAll(p => p.UserId == domainEvent.AggregateEvent.UserId);
        }

        //var admin = AdminList.FirstOrDefault(p => p.UserId == domainEvent.AggregateEvent.UserId);
        //if (admin != null)
        //{
        //    if (domainEvent.AggregateEvent.AdminRights.HasNoRights())
        //    {
        //        AdminList.Remove(admin);
        //    }
        //    else
        //    {
        //        admin.SetAdminRights(domainEvent.AggregateEvent.AdminRights);
        //    }
        //}
        //else
        //{
        //    AdminList.Add(new ChatAdmin(domainEvent.AggregateEvent.PromotedBy,
        //        domainEvent.AggregateEvent.CanEdit,
        //        domainEvent.AggregateEvent.UserId,
        //        domainEvent.AggregateEvent.AdminRights,
        //        domainEvent.AggregateEvent.Rank));
        //}

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelCreatedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        var aggregateEvent = domainEvent.AggregateEvent;

        Id = domainEvent.AggregateIdentity.Value;
        ChannelId = aggregateEvent.ChannelId;
        CreatorId = aggregateEvent.CreatorId;
        Title = aggregateEvent.Title;
        Broadcast = aggregateEvent.Broadcast;
        MegaGroup = aggregateEvent.MegaGroup;
        AccessHash = aggregateEvent.AccessHash;
        About = aggregateEvent.About;
        Address = aggregateEvent.Address;
        Date = aggregateEvent.Date;
        ParticipantsCount = 1;
        Verified = false;
        Signatures = false;
        AdminList = new List<ChatAdmin>();
        TtlPeriod = aggregateEvent.TtlPeriod;
        PhotoId = aggregateEvent.PhotoId;

        AdminList = new List<ChatAdmin>
        {
            new (CreatorId,true,CreatorId,ChatAdminRights.GetCreatorRights(), string.Empty)
        };

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelDefaultBannedRightsEditedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        DefaultBannedRights = domainEvent.AggregateEvent.DefaultBannedRights;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelPhotoEditedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        //Photo = domainEvent.AggregateEvent.Photo;
        PhotoId = domainEvent.AggregateEvent.PhotoId;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelTitleEditedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        Title = domainEvent.AggregateEvent.Title;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, ChannelUserNameChangedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        UserName = domainEvent.AggregateEvent.UserName;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, IncrementParticipantCountEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        //ParticipantsCount++;
        ParticipantsCount = domainEvent.AggregateEvent.NewParticipantCount;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, SetChannelPtsEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        Pts = domainEvent.AggregateEvent.Pts;
        TopMessageId = domainEvent.AggregateEvent.MessageId;
        LastSenderPeerId = domainEvent.AggregateEvent.SenderPeerId;
        LastSendDate = domainEvent.AggregateEvent.Date;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, SlowModeChangedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        SlowModeEnabled = domainEvent.AggregateEvent.Seconds > 0;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, StartSendChannelMessageEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        //TopMessageBoxId = domainEvent.AggregateEvent.MessageBoxId;
        TopMessageId = domainEvent.AggregateEvent.MessageId;

        // LastSendDate = DateTime.UtcNow.ToTimestamp();
        LastSendDate = domainEvent.AggregateEvent.Date;
        LastSenderPeerId = domainEvent.AggregateEvent.SenderPeerId;
        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelMemberAggregate, ChannelMemberId, ChannelMemberBannedRightsChangedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.BannedRights.ViewMessages)
        {
            ParticipantsCount--;
        }
        else if (domainEvent.AggregateEvent.RemovedFromKicked)
        {
            ParticipantsCount++;
        }

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelMemberAggregate, ChannelMemberId, ChannelMemberLeftEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        ParticipantsCount--;
        return Task.CompletedTask;
    }

    //public Task ApplyAsync(IReadModelContext context,
    //    IDomainEvent<ChannelAggregate, ChannelId, CheckChannelStateCompletedEvent> domainEvent,
    //    CancellationToken cancellationToken)
    //{
    //    TopMessageId = domainEvent.AggregateEvent.MessageId;
    //    LastSendDate = domainEvent.AggregateEvent.Date;
    //    LastSenderPeerId = domainEvent.AggregateEvent.SenderPeerId;
    //    return Task.CompletedTask;
    //}
    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelAggregate, ChannelId, DiscussionGroupUpdatedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        LinkedChatId = domainEvent.AggregateEvent.GroupChannelId;
        HasLink = domainEvent.AggregateEvent.GroupChannelId.HasValue;

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context,
        IDomainEvent<ChannelMemberAggregate, ChannelMemberId, ChannelMemberJoinedEvent> domainEvent,
        CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.IsRejoin)
        {
            ParticipantsCount++;
        }

        return Task.CompletedTask;
    }

    //public Task ApplyAsync(IReadModelContext context,
    //    IDomainEvent<ChannelAggregate, ChannelId, ChannelAvailableReactionsChangedEvent> domainEvent,
    //    CancellationToken cancellationToken)
    //{
    //    ReactionType= domainEvent.AggregateEvent.ReactionType;
    //    AllowCustomReaction = domainEvent.AggregateEvent.AllowCustom;
    //    AvailableReactions= domainEvent.AggregateEvent.AvailableReactions;
    //    return Task.CompletedTask;
    //}




    public Task ApplyAsync(IReadModelContext context, IDomainEvent<ChannelAggregate, ChannelId, ChannelColorUpdatedEvent> domainEvent, CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.ForProfile)
        {
            Color = domainEvent.AggregateEvent.Color;

        }
        else
        {
            ProfileColor = domainEvent.AggregateEvent.Color;
        }
        BackgroundEmojiId = domainEvent.AggregateEvent.BackgroundEmojiId;

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context, IDomainEvent<ChannelAggregate, ChannelId, LinkedChannelChangedEvent> domainEvent, CancellationToken cancellationToken)
    {
        LinkedChatId = domainEvent.AggregateEvent.LinkedChannelId;
        HasLink= domainEvent.AggregateEvent.LinkedChannelId.HasValue;

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context, IDomainEvent<DeleteChannelMessagesSaga, DeleteChannelMessagesSagaId, DeleteChannelMessagesCompletedEvent> domainEvent, CancellationToken cancellationToken)
    {
        TopMessageId = domainEvent.AggregateEvent.NewTopMessageId;

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context, IDomainEvent<DeleteReplyMessagesSaga, DeleteReplyMessagesSagaId, DeleteReplyMessagesCompletedEvent> domainEvent, CancellationToken cancellationToken)
    {
        TopMessageId = domainEvent.AggregateEvent.NewTopMessageId;

        return Task.CompletedTask;
    }

    public Task ApplyAsync(IReadModelContext context, IDomainEvent<DeleteChannelMessagesSaga, DeleteChannelMessagesSagaId, DeleteChannelHistoryCompletedEvent> domainEvent, CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.NewTopMessageId != 0)
        {
            TopMessageId = domainEvent.AggregateEvent.NewTopMessageId;
        }

        return Task.CompletedTask;
    }
}