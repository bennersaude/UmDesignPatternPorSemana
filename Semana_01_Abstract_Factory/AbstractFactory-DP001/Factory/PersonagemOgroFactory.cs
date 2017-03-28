using System;

namespace AbstractFactoryDP001
{
	public class PersonagemOgroFactory: PersonagemFactory
	{
		public override Personagem ConstruirPersonagem()
		{
			return new Ogro ();
		}

		public override Equipamento ConstruirEquipamento()
		{
			return new Lanca ();
		}
	}
}

