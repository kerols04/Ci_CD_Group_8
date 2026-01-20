using System;
using System.Globalization;
using System.Linq;

namespace CI_CD_Group_8
{
    public static class PersonnummerValidator
    {
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Ta bort '-' och '+' och mellanslag
            var cleaned = input.Trim().Replace("-", "").Replace("+", "");

            // Tillåt 10 eller 12 siffror
            if (cleaned.Length != 10 && cleaned.Length != 12)
                return false;

            if (!cleaned.All(char.IsDigit))
                return false;

            // Om 12 siffror: använd sista 10 för kontroll
            var tenDigits = cleaned.Length == 12 ? cleaned.Substring(2) : cleaned;

            // Datumdel (YYMMDD)
            var datePart = tenDigits.Substring(0, 6);
            if (!IsValidDate(datePart))
                return false;

            // Luhn på första 9 siffror, jämför med sista
            return IsValidLuhn(tenDigits);
        }

        private static bool IsValidDate(string yymmdd)
        {
            int yy = int.Parse(yymmdd.Substring(0, 2));
            int mm = int.Parse(yymmdd.Substring(2, 2));
            int dd = int.Parse(yymmdd.Substring(4, 2));

            int currentYY = DateTime.Now.Year % 100;
            int century = (yy > currentYY) ? 1900 : 2000;
            int year = century + yy;

            string full = $"{year:D4}{mm:D2}{dd:D2}";
            return DateTime.TryParseExact(
                full,
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _
            );
        }

        private static bool IsValidLuhn(string tenDigits)
        {
            // tenDigits = YYMMDDNNNC (10 siffror)
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int digit = tenDigits[i] - '0';
                int factor = (i % 2 == 0) ? 2 : 1; // 2,1,2,1...
                int product = digit * factor;

                sum += (product > 9) ? product - 9 : product;
            }

            int controlDigit = tenDigits[9] - '0';
            int calculated = (10 - (sum % 10)) % 10;

            return controlDigit == calculated;
        }
    }
}
