using System;

public enum Relationship
{
    Employee,
    Spouse,
    Child
}

public record CoveredPersonRow(
    string LastName,
    string FirstName,
    DateTime BirthDate,
    Relationship Relationship,
    int salary,
    int Months
    // Add column for salary
);

public record ResultRow(
    string LastName,
    string FirstName,
    DateTime BirthDate,
    Relationship Relationship,
    int AgeAsOf12_31,
    int Months,
    decimal ImputedIncome
);