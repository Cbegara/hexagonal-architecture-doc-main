﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S6960:Controllers should not have mixed responsibilities", Justification = "It´s not necessary one controller per action", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.Api.Controllers.VehicleController")]
[assembly: SuppressMessage("Major Code Smell", "S6960:Controllers should not have mixed responsibilities", Justification = "It´s not necessary one controller per action", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.Api.Controllers.RentalController")]
