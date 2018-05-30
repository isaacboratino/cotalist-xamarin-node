using System;
using System.Text.RegularExpressions;

namespace AppCotacao.Services.Utils
{
    class ValidationsUtil
    {
        public static bool IsCNPJValid(string CNPJ)
        {
            const string cnpjRegex = @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)";
            return Regex.IsMatch(CNPJ, cnpjRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool IsEmailValid(string email)
        {
            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
