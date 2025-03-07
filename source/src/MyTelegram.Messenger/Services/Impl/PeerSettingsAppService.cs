﻿namespace MyTelegram.Messenger.Services.Impl;

public class PeerSettingsAppService(IQueryProcessor queryProcessor) : IPeerSettingsAppService //, ISingletonDependency
{
    public async Task<PeerSettings> GetAsync(long userId,
        Peer peer)
    {
        if (userId == peer.PeerId)
        {
            return new PeerSettings();
        }

        var peerSettingsReadModel = await queryProcessor.ProcessAsync(new GetPeerSettingsQuery(userId, peer.PeerId), default);
        if (peerSettingsReadModel != null)
        {
            if (peerSettingsReadModel.HiddenPeerSettingsBar)
            {
                return new PeerSettings();
            }

            if (peerSettingsReadModel.PeerSettings != null)
            {
                return new PeerSettings
                {
                    AddContact = peerSettingsReadModel.PeerSettings.AddContact,
                    BlockContact = peerSettingsReadModel.PeerSettings.BlockContact,
                    NeedContactsException = peerSettingsReadModel.PeerSettings.NeedContactsException,
                    ReportGeo = peerSettingsReadModel.PeerSettings.ReportGeo,
                    ReportSpam = peerSettingsReadModel.PeerSettings.ReportSpam,
                    ShareContact = peerSettingsReadModel.PeerSettings.ShareContact,
                };
            }

            return new PeerSettings
            {

            };
        }

        return new PeerSettings();
    }

    public Task<IPeerSettingsReadModel?> GetPeerSettingsAsync(long userId, long peerId)
    {
        if (userId == peerId)
        {
            return Task.FromResult<IPeerSettingsReadModel?>(null);
        }
        return queryProcessor.ProcessAsync(new GetPeerSettingsQuery(userId, peerId));
    }

    public Task<List<PeerSettings>> GetPeerSettingsListAsync(GetPeerSettingsListInput input)
    {
        return Task.FromResult(new List<PeerSettings>());
    }
}