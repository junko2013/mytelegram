﻿namespace MyTelegram.Domain.Sagas.Events;

public class SignInStartedEvent : RequestAggregateEvent2<SignInSaga, SignInSagaId>
{
    public SignInStartedEvent(RequestInfo requestInfo) : base(requestInfo)
    {
    }
}
