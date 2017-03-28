using System;

namespace AbstractFactoryDP001
{
	public class PersonagemMagoFactory: PersonagemFactory
	{
		public override Personagem ConstruirPersonagem()
		{
			return new Mago ();
		}

		public override Equipamento ConstruirEquipamento()
		{
			return new Cajado ();
		}
	}
}

