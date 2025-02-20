// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Threading;
using System.Threading.Tasks;
using AWS.Messaging.IntegrationTests.Models;

namespace AWS.Messaging.IntegrationTests.Handlers;

public class ChatMessageHandler : IMessageHandler<ChatMessage>
{
    private readonly TempStorage<ChatMessage> _tempStorage;

    public ChatMessageHandler(TempStorage<ChatMessage> tempStorage)
    {
        _tempStorage = tempStorage;
    }

    public Task<MessageProcessStatus> HandleAsync(MessageEnvelope<ChatMessage> messageEnvelope, CancellationToken token = default)
    {
        _tempStorage.Messages.Add(messageEnvelope);

        return Task.FromResult(MessageProcessStatus.Success());
    }
}
