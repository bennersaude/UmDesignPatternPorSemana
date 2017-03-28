using System;

namespace AbstractFactoryDP001
{
	public class Humano : Personagem
	{
		public Humano()
		{
			base.Descricao = "Humano";
			base.Vida = 100;
		}
	}
}

