using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_GERAR_SENHA.models
{
    public class UsuarioInteracao
    {
        public int ObterComprimentoSenha() {
            int comprimento;
                while (true) {
                    Console.WriteLine("Digite o comprimento da sua senha (mínimo 1): ");
                    if (int.TryParse(Console.ReadLine(), out comprimento) && comprimento > 0){
                        return comprimento;
                    }
                    Console.WriteLine("Por favor, insira um valor maior que zero.");
                }
        }

        public bool ObterPreferenciaUsuario(string mensagem) {
            while(true) {
                Console.WriteLine(mensagem);
                string resposta = Console.ReadLine().ToUpper();
                if (resposta == "S") return true;
                if (resposta == "N") return false;
                Console.WriteLine("Por favor, digite apenas 'S' ou 'N'.");
            }
        }
    }
}