namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criação do cardapio da lanchonete
            List<Produto> cardapio = new List<Produto>();
            Produto frango = new Produto { Id = 1, NomeProduto = "1: Pastel de frango", Preco = 6 };
            Produto carne = new Produto { Id = 2, NomeProduto = "2: Pastel de carne", Preco = 6 };
            Produto caldo = new Produto { Id = 3, NomeProduto = "3: Caldo de cana", Preco = 3 };
            Produto acai = new Produto { Id = 4, NomeProduto = "4: Açai com ninho", Preco = 14 };

            cardapio.Add(frango);
            cardapio.Add(carne);
            cardapio.Add(caldo);
            cardapio.Add(acai);
            //Mostrando o cardápio para o cliente


            Console.WriteLine("Cardápio -------");
            foreach (var produto in cardapio)
            {
                produto.Print();
            }
            
            Pedido pedido1 = FazerPedido(cardapio, 1);
            Pedido pedido2 = FazerPedido(cardapio, 2);

            Console.WriteLine("\nPEDIDOS:");
            ExibirPedido(pedido1);
            ExibirPedido(pedido2);
        }
        //Pedido
        static Pedido FazerPedido(List<Produto> cardapio, int numeroPedido)
        {
            Pedido pedido = new Pedido { NumeroPd = numeroPedido };
            string entrada;
            Console.WriteLine($"\nEscolha os produtos pelo ID para adicionar ao seu pedido #{numeroPedido} (digite 'sair' para finalizar):");

            while (true)
            {
                Console.Write("Digite o ID do produto: ");
                entrada = Console.ReadLine();

                if (entrada.ToLower() == "sair")
                    break;

                if (int.TryParse(entrada, out int idEscolhido))
                {
                    Produto produtoSelecionado = cardapio.Find(p => p.Id == idEscolhido);
                    if (produtoSelecionado != null)
                    {
                        pedido.ListaPd.Add(produtoSelecionado);
                        Console.WriteLine($"{produtoSelecionado.NomeProduto} foi adicionado ao seu pedido #{numeroPedido}.");
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite um número de ID válido ou 'sair' para finalizar.");
                }
            }
            return pedido;
        }
        //Metodo para calcular os pedidos
        static void ExibirPedido(Pedido pedido)
        {
            Console.WriteLine($"\nPEDIDO #{pedido.NumeroPd}:");
            if (pedido.ListaPd.Count == 0)
            {
                Console.WriteLine("Nenhum produto foi adicionado a este pedido.");
            }
            else 
            {
                
                double total = 0;
                foreach (var produto in pedido.ListaPd)
                {
                        produto.Print();
                    total += produto.Preco;
                }
                Console.WriteLine($"Total do pedido #{pedido.NumeroPd}: R${total:F2}");
            }
        }
    }
}
