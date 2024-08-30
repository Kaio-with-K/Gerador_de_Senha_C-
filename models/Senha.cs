using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PROJETO_GERAR_SENHA.models {
    public class Senha {
        private int comprimento;
        private bool incluirMaiusculas;
        private bool incluirMinusculas;
        private bool incluirNumeros;
        private bool incluirEspeciais;

        public Senha(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirEspeciais) {
            this.comprimento = comprimento;
            this.incluirMaiusculas = incluirMaiusculas;
            this.incluirMinusculas = incluirMinusculas;
            this.incluirNumeros = incluirNumeros;
            this.incluirEspeciais = incluirEspeciais;
        }

        public string Gerar() {
            const string caracteresMaiusculos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string caracteresMinusculos = "abcdefghijklmnopqrstuvwxyz";
            const string caracteresNumeros = "0123456789";
            const string caracteresEspeciais = "!@#$%&*()";

            StringBuilder caracteresPermitidos = new StringBuilder();

            if (incluirMaiusculas) caracteresPermitidos.Append(caracteresMaiusculos);
            if (incluirMinusculas) caracteresPermitidos.Append(caracteresMinusculos);
            if (incluirNumeros) caracteresPermitidos.Append(caracteresNumeros);
            if (incluirEspeciais) caracteresPermitidos.Append(caracteresEspeciais);

            if (caracteresPermitidos.Length == 0) {
                throw new InvalidOperationException("Nenhum tipo de caractere foi selecionado. Não é possível gerar uma senha.");
            }

            byte[] dadosAleatorios = new byte[comprimento];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(dadosAleatorios);
            }

            StringBuilder senha = new StringBuilder(comprimento);
            foreach (byte b in dadosAleatorios) {
                senha.Append(caracteresPermitidos[b % caracteresPermitidos.Length]);
            }

            return senha.ToString();
        }

    }

}