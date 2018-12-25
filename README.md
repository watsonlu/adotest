# azure-servicebus-sender [![Build Status](https://travis-ci.org/watsonlu/azure-servicebus-sender.svg?branch=master)](https://travis-ci.org/watsonlu/azure-servicebus-sender)
When run, this container puts a message on an azure service bus topic.

# Environment Variables

This container uses environment variables to pass in the service bus information.

**MessageBusConnectionString**
This is the connection string to the message bus.

**MessageBusTopic**
This is the topic that the message will be placed on.

**MessageBody**
This is the content of the message.

**MessageLabel**
This is the label on the message, you can use this to filter messages to a certain subscription. If not supplied, no label will be set.