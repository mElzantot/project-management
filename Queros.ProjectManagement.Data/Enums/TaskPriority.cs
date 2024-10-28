﻿using System.Text.Json.Serialization;

namespace Queros.ProjectManagement.Data.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskPriority
{
    Low,
    Medium,
    High
}