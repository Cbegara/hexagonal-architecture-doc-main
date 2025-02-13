// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure.CompositionRootCollectionFixture")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "Needs to be public for test discovery", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure.MongoDbFixture")]
[assembly: SuppressMessage("Style", "IDE0090:Use 'new(...)'", Justification = "Needed to assign null to a property", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure.MongoDbFixture.InsertInitialData(MongoDB.Driver.IMongoDatabase)")]
