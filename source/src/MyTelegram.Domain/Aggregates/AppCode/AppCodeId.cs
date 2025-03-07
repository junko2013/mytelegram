﻿namespace MyTelegram.Domain.Aggregates.AppCode;

[JsonConverter(typeof(SystemTextJsonSingleValueObjectConverter<AppCodeId>))]
public class AppCodeId(string value) : Identity<AppCodeId>(value)
{
    public static AppCodeId Create(string phoneNumber,
        string phoneCodeHash)
    {
        return NewDeterministic(GuidFactories.Deterministic.Namespaces.Commands, $"{phoneNumber}_{phoneCodeHash}");
    }
}
