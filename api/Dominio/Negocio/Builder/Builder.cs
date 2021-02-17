using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Negocio.Builder
{
    public static class BuilderEntidade
    {
        public static T ConverteEntidade<T>(object objectParam)
        {
            var entity = Activator.CreateInstance<T>();
            foreach (var field in objectParam.GetType().GetProperties())
            {
                var value = objectParam.GetType().GetProperty(field.Name).GetValue(objectParam);
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
