# High Level Design

The following is the high level design of Megaphone. This is built with [Dapr](http://dapr.io), an event-driven, portable runtime for building microservices on cloud and edge. Dapr is currently under community development in preview phase and master branch could include breaking changes.

Dapr is language agnostic and provides a [RESTful HTTP API](https://github.com/dapr/docs/blob/master/reference/api/README.md) in addition to the protobuf clients. Megaphone uses the RESTful API for the Crawler service and leverages the [Dapr SDK for .NET](https://github.com/dapr/dotnet-sdk) for the other services.

## Architecture Design

![megaphone design](./media/megaphone.svg)

## Organic View genetated by Azure Application Insights

![megaphone organic view](./media/megaphone-organic-view-application-insights.jpg)

## Hierarchical View genetated by Azure Application Insights

![megaphone organic view](./media/megaphone-hierarchical-view-application-insights.jpg)