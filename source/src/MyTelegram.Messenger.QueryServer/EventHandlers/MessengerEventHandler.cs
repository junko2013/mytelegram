﻿namespace MyTelegram.Messenger.QueryServer.EventHandlers;

public class MessengerEventHandler(
    IMessageQueueProcessor<MessengerQueryDataReceivedEvent> processor,
    IObjectMessageSender objectMessageSender,
    ILogger<MessengerEventHandler> logger)
    :
        IEventHandler<MessengerQueryDataReceivedEvent>,
        IEventHandler<StickerDataReceivedEvent>
{
    public Task HandleEventAsync(MessengerQueryDataReceivedEvent eventData)
    {
        processor.Enqueue(eventData, eventData.PermAuthKeyId);
        return Task.CompletedTask;
    }

    public Task HandleEventAsync(StickerDataReceivedEvent eventData)
    {
        processor.Enqueue(
            new MessengerQueryDataReceivedEvent(eventData.ConnectionId, eventData.RequestId, eventData.ObjectId,
                eventData.UserId, eventData.ReqMsgId, eventData.SeqNumber, eventData.AuthKeyId, eventData.PermAuthKeyId,
                eventData.Data, eventData.Layer, eventData.Date, eventData.DeviceType, eventData.ClientIp), eventData.AuthKeyId);
        return Task.CompletedTask;
    }

    public Task HandleEventAsync(UserIsOnlineEvent eventData)
    {
        logger.LogDebug("User {UserId} is online,tempAuthKeyId={TempAuthKeyId:x2},permAuthKeyId={PermAuthKeyId:x2}",
            eventData.UserId,
            eventData.TempAuthKeyId,
            eventData.PermAuthKeyId);
        var updatesTooLong = new TUpdatesTooLong();
        return objectMessageSender.PushSessionMessageToAuthKeyIdAsync(eventData.TempAuthKeyId, updatesTooLong);
    }
}