using System.Collections.Generic;
using System.Linq;

namespace Conceitos.InjecaoDependencias.IoC.ComIoC.Entregas
{
    public class EntregaSaladaFrutas
    {
        public IEnumerable<Fruta> EntregarSaladaFrutas()
        {
            var entregas = new[] {
                new EntregaFrutas(new Maca()),
                new EntregaFrutas(new Goiaba())
            };

            return entregas.Select(e => e.Entregar());
        }
    }
}
