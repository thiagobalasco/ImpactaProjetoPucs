using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PucsMVC.Models.EF
{
    public class Cliente : Entity
    {

        #region Propriedades Mapeadas

        [Display(Name = "Razão Social/Nome"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RazaoSocial { get; set; }

        [Display(Name = "Fantasia"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Fantasia { get; set; }

        [Display(Name = "CPF/CNPJ"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CNPJ { get; set; }

        [Display(Name = "RG/I.E."), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? IE { get; set; }

        [Display(Name = "Cep"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Cep { get; set; }

        [Display(Name = "Endereço"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Endereco { get; set; }

        [Display(Name = "Bairro"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Bairro { get; set; }

        [Display(Name = "Município"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Municipio { get; set; }

        [Display(Name = "UF"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UF { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }


        [Display(Name = "Status"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Status { get; set; }

        [Display(Name = "DDD"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? DDD { get; set; }

        [Display(Name = "E-mail"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Email { get; set; }

        [Display(Name = "Tel.1"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Tel1 { get; set; }

        [Display(Name = "Tel.2"), DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Tel2 { get; set; }

        [Display(Name = "Observação")]
        public string? Observacao { get; set; }

        [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        #endregion

        #region Métodos


        public static bool ValidaCPF(string cpf)
        {
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidaCNPJ(string cnpj)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.Length != 14)
                    return false;
                tempCnpj = cnpj.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpj.EndsWith(digito);
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidadeIE(string IE)
        {
            if (string.IsNullOrEmpty(IE)
                || IE.Length <= 5)
            {
                return false;
            }

            bool onlyNumber = true;

            foreach (var s in IE)
            {
                if (!"0123456789".Contains(s))
                {
                    onlyNumber = false;
                    continue;
                }
            }

            if (onlyNumber)
            {
                return onlyNumber;
            }

            return IE.Trim().Equals("ISENTO");
        }

        public static bool ValidaRG(string IE)
        {
            if (string.IsNullOrEmpty(IE)
                 || IE.Length <= 6)
            {
                return false;
            }

            bool onlyNumber = true;

            foreach (var s in IE)
            {
                if (!"0123456789".Contains(s))
                {
                    onlyNumber = false;
                    continue;
                }
            }

            if (onlyNumber)
            {
                return onlyNumber;
            }

            return true;
        }


        #endregion



    }
}
