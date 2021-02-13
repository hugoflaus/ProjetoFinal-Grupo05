using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Negocio.Builder
{
    public class BuilderPessoa
    {
        public static T ConverteEntidade<T>(object pessoaSalvar)
        {
            var entity = Activator.CreateInstance<T>();
            foreach (var field in pessoaSalvar.GetType().GetProperties())
            {
                var value = pessoaSalvar.GetType().GetProperty(field.Name).GetValue(pessoaSalvar);
                if (value != null)
                {
                    var prop = entity.GetType().GetProperty(field.Name);
                    if (prop != null) prop.SetValue(entity, value);
                }
            }

            return entity;
        }
    }
}
