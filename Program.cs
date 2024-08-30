using PROJETO_GERAR_SENHA.models;
using System.Security.Cryptography;

class Program
{
     static void Main(string[] args){
          Console.WriteLine("Bem-vindos ao gerador de senhas do Kaio com K!");

          bool executando = true;
          UsuarioInteracao usuarioInteracao = new UsuarioInteracao();

          while (executando){
               int comprimento = usuarioInteracao.ObterComprimentoSenha();

               bool incluirMaiusculas = usuarioInteracao.ObterPreferenciaUsuario("Deseja incluir letras maiúsculas? (S/N) ");
               bool incluirMinusculas = usuarioInteracao.ObterPreferenciaUsuario("Deseja incluir letras minúsculas? (S/N) ");
               bool incluirNumeros = usuarioInteracao.ObterPreferenciaUsuario("Deseja incluir números? (S/N) ");
               bool incluirEspeciais = usuarioInteracao.ObterPreferenciaUsuario("Deseja incluir caracteres especiais? (S/N) ");

               Senha senha = new Senha(comprimento, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirEspeciais);
               Console.WriteLine("Senha gerada: " + senha.Gerar());

               executando = usuarioInteracao.ObterPreferenciaUsuario("Deseja gerar outra senha? (S/N) ");
          }
     }
}
