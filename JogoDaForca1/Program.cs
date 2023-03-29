namespace JogoDaForca1
{
    internal class Program
    {

        static int tentativasJogador = 5;
        static string palavraAleatoriaDoJogo;

        static List<string> letrasErradas = new List<string>();
        static List<string> letraCertas = new List<string>();

        static string[] palavrasJogos = { "Abacate", "Abacaxi", "Acerola", "Açaí", "Araça", "Bacaba", "Bacuri", "Banana", "Cajá", "Cajú", "Carambola", "Cupuaçu", "graviola", "Goiaba", "Jabuticaba", "Jenipapo", "Maça", "Mangaba", "Manga", "Maracujá", "Murici", "Pequi", "Pitanga", "Pitaya", "Sapoti", "Tangerina", "Umbu", "Uva", "Uvaia" };




        static void Main(string[] args)
        {
            Console.WriteLine("Desafio Jogo da Forca");

            do
            {
                Console.Clear();
                palavraAleatoria();
                inicializarJogo();



            } while (true);
        }






        static void palavraAleatoria()
        {
            Random random = new Random();
            int indexPalavraRandomica = random.Next(0, 29);
            palavraAleatoriaDoJogo = palavrasJogos[indexPalavraRandomica];
        }






        static void inicializarJogo()
        {
            letrasErradas = new List<string>();
            letraCertas = new List<string>();
            tentativasJogador = 5;

            do //faça
            {
                Console.Clear();
                string palavraToUpper = palavraAleatoriaDoJogo.ToUpper();
                Console.WriteLine(palavraToUpper);
                Console.WriteLine("\n\n");
                char[] arrayPalavraRandomica = palavraToUpper.ToCharArray();

                int contadorAuxiliar = 0;

                desenharForca();

                if (tentativasJogador <= 0)
                {
                    Console.WriteLine("VOCÊ PERDEU, TENTE NOVAMENTE");
                    Console.ReadLine();
                    return;
                }
                //para cada
                foreach (char c in arrayPalavraRandomica)
                {

                    if (letraCertas.Contains(c.ToString()))
                    {
                        Console.Write(c);
                        contadorAuxiliar++;
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }

                Console.WriteLine("\n\n");

                if (palavraAleatoriaDoJogo.Length == contadorAuxiliar)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PARABÉNS VOCÊ VENCEU!");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }

                mostrarLetrasErradas();

                Console.WriteLine($"\n\nSuas tentativas: {tentativasJogador}");

                Console.Write("Chute uma letra: ");
                string letraChutada = Console.ReadLine();

                letraChutada = letraChutada.ToUpper();
                verificarLetraChutada(letraChutada);

                //enquanto
            } while (tentativasJogador != -1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Você perdeu! Aperte enter para jogar novamente!");
            Console.ResetColor();
            Console.ReadLine();
        }






        static void desenharForca()
        {
            Console.WriteLine(" ________");
            Console.WriteLine(" |      |");
            Console.WriteLine(" |      " + (tentativasJogador < 5 ? "O" : ""));
            Console.WriteLine(" |     " + (tentativasJogador < 3 ? "/" : "") + (tentativasJogador < 4 ? "|" : "") + (tentativasJogador < 2 ? "\\" : ""));
            Console.WriteLine(" |     " + (tentativasJogador < 2 ? "/" : "") + " " + (tentativasJogador < 1 ? "\\" : ""));
            Console.WriteLine("_|_");

            Console.WriteLine("\n\n");
        }







        static void mostrarLetrasErradas()
        {
           
            Console.Write("Letras erradas: ");
            letrasErradas.ForEach(x => Console.Write($"{x} "));
           
        }







        static void verificarLetraChutada(string letra)
        {
            string palavrasToUpper = palavraAleatoriaDoJogo.ToUpper();

            int index = palavrasToUpper.IndexOf(letra);

            if (index == -1)
            {
               
                letrasErradas.Add(letra);
                Console.WriteLine("\nEssa letra não tem na palvra secreta! \n");
                tentativasJogador--;
                
                Console.ReadLine();
                return;
            }
            else
            {
               
                Console.WriteLine("\nLetra certa!");
                letraCertas.Add(letra);
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

        }
    }
}