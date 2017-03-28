using System;

namespace AbstractFactoryDP001
{
	public class PersonagemHumanoFactory : PersonagemFactory
	{
		public override Personagem ConstruirPersonagem()
		{
			return new Humano ();
		}

		public override Equipamento ConstruirEquipamento()
		{
			return new Espada ();
		}
	}
}

