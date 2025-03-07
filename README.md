# MyTelegram

[![API Layer](https://img.shields.io/badge/API_Layer-177-blueviolet)](https://corefork.telegram.org/methods)
[![MTProto](https://img.shields.io/badge/MTProto_Protocol-2.0-green)](https://corefork.telegram.org/mtproto/)
[![Support Chat](https://img.shields.io/badge/Chat_with_us-on_Telegram-0088cc)](https://t.me/+S-aNBoRvCRpPyXrR)

MyTelegram is telegram server side api implementation written in c#,support private deployment

## Features

- API Layer: **`177`**
- [MTProto transports](https://corefork.telegram.org/mtproto/mtproto-transports): **`Abridged`**,**`Intermediate`**
- Private chat
- Group chat
- Supergroup chat
- Channel
- End-to-end-encryption chat(Pro version)
- Voice/video call(Pro version)
- Bot(Partial support,Pro version)
- 2FA(Pro version)
- Stickers(Pro version)
- Reactions(Pro version)
- ForumTopics(Pro version)

## Build MyTelegram Server

1. Install [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. Run `build/build.ps1` ([PowerShell7+](https://github.com/PowerShell/PowerShell))
3. Build output folder is `out/{version}`

## Build docker images

Run the following scripts

```
build\docker\1.build-messenger-command-server.sh
build\docker\2.build-messenger-query-server.sh
build\docker\3.build-messenger-server-grpcservice.sh
build\docker\4.build-sms-sender.sh
build\docker\5.build-gateway-server.sh
```

## Run MyTelegram server

- ### Run MyTelegram server with docker

1. Download docker-compose configuration files
   ```
   https://raw.githubusercontent.com/loyldg/mytelegram/dev/docker/compose/docker-compose.yml
   https://raw.githubusercontent.com/loyldg/mytelegram/dev/docker/compose/.env
   ```
2. Replace `192.168.1.100` with your own server IP in `.env`
3. Run the following command in the directory where the docker-compose.yml file is located
   ```
   Linux: docker compose up
   Windows: docker-compose --env-file .env up 
   ```

- ### Run MyTelegram manually

1. Download mytelegram server from [https://github.com/loyldg/mytelegram/releases](https://github.com/loyldg/mytelegram/releases)
2. Install Redis
3. Install MongoDB
4. Intall RabbitMQ
5. Install Minio
6. Replace `192.168.1.100` with your own server IP in `start-all.bat`
7. Run `start-all.bat`
8. Run telegram client 
4. Default verification code is `22222`

## MyTelegram clients
[TDesktop for mytelegram](https://github.com/loyldg/mytelegram-tdesktop)

[Android client for mytelegram](https://github.com/loyldg/mytelegram-android)

[iOS client for mytelegram](https://github.com/loyldg/mytelegram-iOS)

[WebK for mytelegram](https://github.com/loyldg/mytelegram-webk)

[WebA for mytelegram](https://github.com/loyldg/mytelegram-weba)

1. Git clone the client source code
2. Replace `192.168.1.100` with your server IP

## Support MyTelegram

Love MyTelegram? Please give a star to this repository ⭐

## Feedback

Contact author:[https://t.me/mytelegram666](https://t.me/mytelegram666)  
Join telegram group:[https://t.me/+S-aNBoRvCRpPyXrR](https://t.me/+S-aNBoRvCRpPyXrR)
