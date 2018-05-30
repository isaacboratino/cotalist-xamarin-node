using System.Text.RegularExpressions;

namespace AppCotacao.Services.Utils
{
    public class MasksUtil
    {
        public static string AddMaskCNPJ(string CNPJ)
        {
            int digitos = 14;
            string CNPJMasked = Regex.Replace(CNPJ, @"[^0-9]", "");

            CNPJMasked = CNPJMasked.PadRight(digitos);

            // Remover todos os digitos excedentes 
            if (CNPJMasked.Length > digitos)
            {
                CNPJMasked = CNPJMasked.Remove(digitos);
            }

            CNPJMasked = CNPJMasked.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-").TrimEnd(new char[] { ' ', '.', '-', '/' });
            return CNPJMasked;
        }

        public static string AddMaskCPF(string CPF)
        {
            int digitos = 11;
            string CPFMasked = Regex.Replace(CPF, @"[^0-9]", "");

            CPFMasked = CPFMasked.PadRight(digitos);

            // Remover todos os digitos excedentes 
            if (CPFMasked.Length > digitos)
            {
                CPFMasked = CPFMasked.Remove(digitos);
            }

            CPFMasked = CPFMasked.Insert(3, ".").Insert(7, ".").Insert(11, "-").TrimEnd(new char[] { ' ', '.', '-' });
            return CPFMasked;
        }

        public static string RemoveMaskCNPJ(string CNPJ)
        {
            return MasksUtil.RemoveMask(CNPJ);
        }

        public static string RemoveMaskCPF(string CPF)
        {
            return MasksUtil.RemoveMask(CPF);
        }

        private static string RemoveMask(string text)
        {
            return Regex.Replace(text, "[./-]", "");
        }
    }
}
