using System;

namespace AbstractFactoryDP001
{
	public class Lanca : Equipamento
	{
		public Lanca ()
		{
			base.Dano = 15;
			base.Defesa = 8;
			base.Descricao = "Lança com escudo";
		}
	}
}

