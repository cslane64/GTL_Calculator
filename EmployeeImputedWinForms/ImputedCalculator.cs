using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EmployeeImputedWinForms
{
    public static class ImputedCalculator
    {
        public static List<CoveredPersonRow> LoadCsv(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length < 2) return new();

            string headerLine = lines[0].Trim().Trim('\uFEFF'); // remove BOM if present
            char delimiter = DetectDelimiter(headerLine);

            var header = SplitLine(headerLine, delimiter);

            int idxLast = IndexOfAny(header, "Last", "LastName", "Last Name", "Surname");
            int idxFirst = IndexOfAny(header, "First", "FirstName", "First Name", "Given Name");
            int idxDob = IndexOfAny(header, "DOB", "BirthDate", "Birth Date", "DateOfBirth", "Date of Birth");
            int idxType = IndexOfAny(header, "Dependent type", "Relationship", "DependentType", "Type");
            int idxMonths = IndexOfAny(header, "Months", "Month", "NumberOf Months");

            var rows = new List<CoveredPersonRow>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                var cols = SplitLine(lines[i], delimiter);

                if (cols.Length < header.Length)
                {
                    throw new InvalidOperationException(
                        $"Line {i + 1} has {cols.Length} columns but header has {header.Length}.");
                }

                string last = cols[idxLast];
                string first = cols[idxFirst];
                string dobText = cols[idxDob];
                string typeText = cols[idxType];
                string monthsText = cols[idxMonths];

                if (!DateTime.TryParse(dobText, CultureInfo.GetCultureInfo("en-US"),
                        DateTimeStyles.None, out var dob))
                {
                    throw new InvalidOperationException($"Invalid DOB '{dobText}' on line {i + 1}.");
                }

                if (!int.TryParse(monthsText, out var months))
                {
                    throw new InvalidOperationException($"Invalid Months '{monthsText}' on line {i + 1}.");
                }

                var rel = ParseRelationship(typeText);

                rows.Add(new CoveredPersonRow(last, first, dob, rel, months));
            }

            return rows;
        }

        public static List<ResultRow> Compute(List<CoveredPersonRow> input, int year)
        {
            var asOf = new DateTime(year, 12, 31);

            return input.Select(r =>
            {
                int age = AgeAsOf(r.BirthDate, asOf);

                decimal imputed = r.Relationship switch
                {
                    Relationship.Employee =>
                        ((250000m - 50000m) / 1000m) * GetAgeBandRate(age) * r.Months, // 200 * rate * months

                    // keep your existing placeholder logic for non-employees (or replace if you have real rules)
                    Relationship.Spouse =>
                        (10000 / 1000m) * GetAgeBandRate(age) * r.Months, // 10 * rate * months
                    Relationship.Child =>
                        (5000m / 1000m) * GetAgeBandRate(age) * r.Months, // 5 * rate * months,
                    _ => 0m
                };

                return new ResultRow(
                    r.LastName,
                    r.FirstName,
                    r.BirthDate,
                    r.Relationship,
                    age,
                    r.Months,
                    decimal.Round(imputed, 2, MidpointRounding.AwayFromZero)
                );
            }).ToList();
        }

        private static decimal GetAgeBandRate(int age)
        {
            // IRS Table I monthly cost per $1,000 (commonly used for GTL imputed income)
            if (age < 25) return 0.05m;
            if (age <= 29) return 0.06m;
            if (age <= 34) return 0.08m;
            if (age <= 39) return 0.09m;
            if (age <= 44) return 0.10m;
            if (age <= 49) return 0.15m;
            if (age <= 54) return 0.23m;
            if (age <= 59) return 0.43m;
            if (age <= 64) return 0.66m;
            if (age <= 69) return 1.27m;
            return 2.06m; // 70+
        }

        private static int AgeAsOf(DateTime dob, DateTime asOf)
        {
            int age = asOf.Year - dob.Year;
            if (dob.Date > asOf.AddYears(-age).Date) age--;
            return age;
        }

        private static Relationship ParseRelationship(string s)
        {
            s = (s ?? "")
                .Trim()
                .Trim('"')
                .ToLowerInvariant();

            return s switch
            {
                "employee" => Relationship.Employee,
                "spouse" => Relationship.Spouse,
                "dependent child" or "child" or "dependent" => Relationship.Child,
                _ => throw new InvalidOperationException($"Unknown relationship/dependent type '{s}'")
            };
        }

        private static char DetectDelimiter(string headerLine)
        {
            if (headerLine.Contains('\t')) return '\t'; // Excel tab-delimited
            return ',';
        }

        private static string[] SplitLine(string line, char delimiter) =>
    line.Split(delimiter)
        .Select(x => Unquote(x.Trim()))
        .ToArray();

        private static string Unquote(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            // Remove wrapping quotes: "employee" -> employee
            if (s.Length >= 2 && s.StartsWith("\"") && s.EndsWith("\""))
                s = s.Substring(1, s.Length - 2);

            // Unescape doubled quotes inside quoted CSV values
            s = s.Replace("\"\"", "\"");

            return s.Trim();
        }

        private static int IndexOfAny(string[] header, params string[] names)
        {
            foreach (var n in names)
            {
                int idx = IndexOfOrMinusOne(header, n);
                if (idx >= 0) return idx;
            }

            throw new InvalidOperationException(
                $"Missing required column. Expected one of: {string.Join(", ", names)}. " +
                $"Found columns: {string.Join(" | ", header)}");
        }

        private static int IndexOfOrMinusOne(string[] header, string name)
        {
            static string Normalize(string s) =>
                (s ?? "")
                    .Trim()
                    .Trim('\uFEFF')
                    .Replace("_", "")
                    .Replace(" ", "")
                    .ToLowerInvariant();

            string target = Normalize(name);

            for (int i = 0; i < header.Length; i++)
            {
                if (Normalize(header[i]) == target)
                    return i;
            }

            return -1;
        }
    }
}