﻿global using EventFlow.MongoDB.ReadStores;
global using EventFlow.Queries;
global using MongoDB.Driver;
global using MyTelegram.Domain.Aggregates.Channel;
global using MyTelegram.Domain.Aggregates.Chat;
global using MyTelegram.Domain.Aggregates.Contact;
global using MyTelegram.Domain.Aggregates.Device;
global using MyTelegram.Domain.Aggregates.Pts;
global using MyTelegram.Domain.Aggregates.User;
global using MyTelegram.Domain.Aggregates.UserName;
global using MyTelegram.Queries;
global using MyTelegram.ReadModel;
global using MyTelegram.EventFlow.MongoDB;
global using System.Linq.Expressions;
global using MyTelegram.Domain.ValueObjects;
global using MyTelegram.EventFlow.ReadStores;
global using EventFlow;
global using EventFlow.Extensions;


global using AppCodeReadModel = MyTelegram.ReadModel.MongoDB.AppCodeReadModel;
//global using BotReadModel = MyTelegram.ReadModel.MongoDB.BotReadModel;
global using ChannelFullReadModel = MyTelegram.ReadModel.MongoDB.ChannelFullReadModel;
global using ChannelMemberReadModel = MyTelegram.ReadModel.MongoDB.ChannelMemberReadModel;
global using ChannelReadModel = MyTelegram.ReadModel.MongoDB.ChannelReadModel;
global using ChatInviteReadModel = MyTelegram.ReadModel.MongoDB.ChatInviteReadModel;
global using ChatReadModel = MyTelegram.ReadModel.MongoDB.ChatReadModel;
global using DeviceReadModel = MyTelegram.ReadModel.MongoDB.DeviceReadModel;
global using DialogReadModel = MyTelegram.ReadModel.MongoDB.DialogReadModel;
global using DraftReadModel = MyTelegram.ReadModel.MongoDB.DraftReadModel;
global using MessageReadModel = MyTelegram.ReadModel.MongoDB.MessageReadModel;
global using PeerNotifySettingsReadModel = MyTelegram.ReadModel.MongoDB.PeerNotifySettingsReadModel;
global using PtsForAuthKeyIdReadModel = MyTelegram.ReadModel.MongoDB.PtsForAuthKeyIdReadModel;
global using PtsReadModel = MyTelegram.ReadModel.MongoDB.PtsReadModel;
//global using PushUpdatesReadModel = MyTelegram.ReadModel.MongoDB.PushUpdatesReadModel;
global using ReadingHistoryReadModel = MyTelegram.ReadModel.MongoDB.ReadingHistoryReadModel;
global using RpcResultReadModel = MyTelegram.ReadModel.MongoDB.RpcResultReadModel;
global using UserNameReadModel = MyTelegram.ReadModel.MongoDB.UserNameReadModel;
global using UserReadModel = MyTelegram.ReadModel.MongoDB.UserReadModel;
global using ReplyReadModel = MyTelegram.ReadModel.MongoDB.ReplyReadModel;
global using DialogFilterReadModel = MyTelegram.ReadModel.MongoDB.DialogFilterReadModel;
global using PollReadModel = MyTelegram.ReadModel.MongoDB.PollReadModel;
global using PollAnswerVoterReadModel = MyTelegram.ReadModel.MongoDB.PollAnswerVoterReadModel;
global using AccessHashReadModel = MyTelegram.ReadModel.MongoDB.AccessHashReadModel;
global using PeerSettingsReadModel = MyTelegram.ReadModel.MongoDB.PeerSettingsReadModel;
global using PhotoReadModel = MyTelegram.ReadModel.MongoDB.PhotoReadModel;
global using ChatAdminReadModel = MyTelegram.ReadModel.MongoDB.ChatAdminReadModel;
global using UpdatesReadModel = MyTelegram.ReadModel.MongoDB.UpdatesReadModel;
global using ChatInviteImporterReadModel = MyTelegram.ReadModel.MongoDB.ChatInviteImporterReadModel;
global using ContactReadModel = MyTelegram.ReadModel.MongoDB.ContactReadModel;