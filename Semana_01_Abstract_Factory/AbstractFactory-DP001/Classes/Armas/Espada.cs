using System;

namespace AbstractFactoryDP001
{
	public class Espada : Equipamento
	{
		public Espada ()
		{
			base.Dano = 15;
			base.Defesa = 4;
			base.Descricao = "Espada";
		}
	}
}

