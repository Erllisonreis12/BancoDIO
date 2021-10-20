using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoTeste
{
    class Program
    {
        public static void  Main (string[] args) 
        {
            while(true){
                String senha = Console.ReadLine();
                if(String.IsNullOrEmpty(senha)) break;

                var vetor = senha.ToCharArray(0,senha.Length);
                bool cont = false;

                foreach(char v in vetor){
                    if(Char.IsUpper(v)){cont = true; break;};
        
                }
                //Console.WriteLine(cont);
                if( (senha.Length < 6 && senha.Length < 32) ||
                    (senha.Any(ch => Char.IsPunctuation(ch) || Char.IsSeparator(ch))) ||
                    !cont
                ){
                    Console.WriteLine("Senha Inválida");
                }else{
                    Console.WriteLine("Senha Válida");
                }
            }    
        }
    }
}