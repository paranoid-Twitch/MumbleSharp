﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MumbleSharp.Model;
using MumbleSharp.Packets;

namespace MumbleSharp
{
    /// <summary>
    /// An object which handles the higher level logic of a connection to a mumble server
    /// </summary>
    public interface IMumbleProtocol
    {
        /// <summary>
        /// The user of the local client
        /// </summary>
        User LocalUser { get; }

        /// <summary>
        /// The root channel of the server
        /// </summary>
        Channel RootChannel { get; }

        /// <summary>
        /// All channels on the server
        /// </summary>
        IEnumerable<Channel> Channels { get; }

        /// <summary>
        /// All users on the server
        /// </summary>
        IEnumerable<User> Users { get; }

        void Initialise(MumbleConnection connection);

        bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors);

        void Version(Packets.Version version);

        void ChannelState(ChannelState channelState);

        void UserState(UserState userState);

        void CodecVersion(CodecVersion codecVersion);

        void ContextAction(ContextAction contextAction);

        void ContextActionAdd(ContextActionAdd contextActionAdd);

        void PermissionQuery(PermissionQuery permissionQuery);

        void ServerSync(ServerSync serverSync);

        void ServerConfig(ServerConfig serverConfig);

        void Udp(byte[] packet);

        void Ping(Ping ping);

        void UserRemove(UserRemove userRemove);

        void ChannelRemove(ChannelRemove channelRemove);

        void TextMessage(TextMessage textMessage);

        void UserList(UserList userList);
    }
}
