// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0

using AWS.Messaging.Serialization;

namespace AWS.Messaging.Configuration;

/// <summary>
/// Interface for the message configuration.
/// </summary>
public interface IMessageConfiguration
{
    /// <summary>
    /// Maps the message types to a publisher configuration
    /// </summary>
    IList<PublisherMapping> PublisherMappings { get; }

    /// <summary>
    /// Returns back the publisher mapping for the given message type.
    /// </summary>
    /// <param name="messageType">The Type of the message</param>
    /// <returns>The <see cref="PublisherMapping"/> containing routing info for the specified message type.</returns>
    PublisherMapping? GetPublisherMapping(Type messageType);

    /// <summary>
    /// Maps the message types to a subscriber configuration
    /// </summary>
    IList<SubscriberMapping> SubscriberMappings { get; }

    /// <summary>
    /// Returns back the subscriber mapping for the given message type.
    /// </summary>
    /// <param name="messageType">The Type of the message</param>
    /// <returns>The <see cref="SubscriberMapping"/> containing routing info for the specified message type.</returns>
    SubscriberMapping? GetSubscriberMapping(Type messageType);

    /// <summary>
    /// Returns back the subscriber mapping for the given message type identifier.
    /// </summary>
    /// <param name="messageTypeIdentifier">The language agnostic identifier for the application message</param>
    /// <returns>The <see cref="SubscriberMapping"/> containing routing info for the specified message type.</returns>
    SubscriberMapping? GetSubscriberMapping(string messageTypeIdentifier);

    /// <summary>
    /// List of configurations for subscriber to poll for messages from an AWS service endpoint.
    /// </summary>
    IList<IMessagePollerConfiguration> MessagePollerConfigurations { get; set; }

    /// <summary>
    /// Holds an instance of <see cref="SerializationOptions"/> to control the serialization/de-serialization of the application message.
    /// </summary>
    SerializationOptions SerializationOptions { get; }

    /// <summary>
    /// Holds instances of <see cref="ISerializationCallback"/> that lets users inject their own metadata to incoming and outgoing messages.
    /// </summary>
    IList<ISerializationCallback> SerializationCallbacks { get; }
}
