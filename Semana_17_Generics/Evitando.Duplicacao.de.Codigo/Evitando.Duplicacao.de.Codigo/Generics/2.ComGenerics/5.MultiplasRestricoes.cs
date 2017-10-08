using System;

namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
	public interface IUmaCoisa
    {
        void FazerUmaCoisa();
    }

	public interface IDuasCoisas
    {
        void FazerDuasCoisas();
    }

    public class FazAlgumasCoisas : IUmaCoisa, IDuasCoisas
    {
        public void FazerUmaCoisa() { }
        public void FazerDuasCoisas() { }
    }

	public class QuerFazerVariasCoisas<T> where T : IUmaCoisa, IDuasCoisas
    {
        public QuerFazerVariasCoisas(T fazMuitasCoisas)
        {
            fazMuitasCoisas.FazerUmaCoisa();
            fazMuitasCoisas.FazerDuasCoisas();

            new QuerFazerVariasCoisas<FazAlgumasCoisas>(new FazAlgumasCoisas());
        }
    }
}
