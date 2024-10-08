﻿namespace Library.API.Contracts.Book;

public sealed record CreateBookRequest(
    string Title, 
    string Author, 
    string Publisher, 
    int PageCount, 
    string Summary, 
    string Language, 
    DateTime PublicationYear);

