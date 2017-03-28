using System;

namespace AbstractFactoryDP001
{
	public class Cajado : Equipamento
	{
		public Cajado ()
		{
			base.Dano = 5;
			base.Defesa = 15;
			base.Descricao = "Cajado";
		}
	}
}

