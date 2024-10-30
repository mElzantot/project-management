﻿namespace Queros.ProjectManagement.DTOs;

public class AuthResponseDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime ExpiryDate { get; set; }
}