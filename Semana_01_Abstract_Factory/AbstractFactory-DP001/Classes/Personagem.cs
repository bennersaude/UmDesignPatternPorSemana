using System;

namespace AbstractFactoryDP001
{
	public abstract class Personagem
	{
		public string Descricao {get;set;}
		public int Vida {get;set;}
		public Equipamento EquipamentoPrincipal {get;set;}
	}
}

