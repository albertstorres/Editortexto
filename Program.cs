using System;
using System.IO;

namespace EditorTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um arquivo");
            Console.WriteLine("0 - Sair");

            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: AbrirArquivo(); break;
                case 2: CriarArquivo(); break;
                case 0: System.Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void CriarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Esc - Sair");
            Console.WriteLine("Digite seu texto aqui");
            Console.WriteLine("--------------------------------");

            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        static void AbrirArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo: ");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho))
            {
                var texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();

            Menu();
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine("Arquivo salvo com sucesso!");
            Console.ReadLine();

            Menu();
        }
    }
}
