using System;

namespace AbstractFactoryDP001
{
	public class Ogro : Personagem
	{
		public Ogro(){
			base.Descricao = "Ogro";
			base.Vida = 100;
		}
	}
}

