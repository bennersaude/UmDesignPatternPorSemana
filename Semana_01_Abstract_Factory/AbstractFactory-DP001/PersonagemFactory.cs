using System;

namespace AbstractFactoryDP001
{
	public abstract class PersonagemFactory
	{
		public abstract Personagem ConstruirPersonagem ();
		public abstract Equipamento ConstruirEquipamento ();
	}
}

