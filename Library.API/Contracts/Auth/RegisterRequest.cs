﻿namespace Library.API.Contracts.Auth;

public sealed record RegisterRequest(
    string FirstName, 
    string LastName,
    string Email, 
    string Password);
