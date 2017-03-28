using System;

namespace AbstractFactoryDP001
{
    public class CriacaoPersonagem
    {
        private PersonagemFactory factory;

        public CriacaoPersonagem(PersonagemFactory factory)
        {
            this.factory = factory;
        }

        public Personagem ObterPersonagem()
        {
            var personagem = factory.ConstruirPersonagem();
            var equipamento = factory.ConstruirEquipamento();
            personagem.EquipamentoPrincipal = equipamento;

            return personagem;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Personagem personagem = new CriacaoPersonagem(new PersonagemHumanoFactory()).ObterPersonagem();

            Console.WriteLine("Você construiu um " + personagem.Descricao + " com o equipamento " + personagem.EquipamentoPrincipal.Descricao + " em mãos");
            Console.ReadKey();
        }
    }
}
