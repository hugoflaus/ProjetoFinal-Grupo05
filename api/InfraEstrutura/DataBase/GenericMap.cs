using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace api.InfraEstrutura.DataBase
{
    public class GenericMap
    {
    public static string BuilderInsert<T>(T dado)
    {
        var nome = $"{dado.GetType().Name.ToLower()}s";
        var tabela = dado.GetType().GetCustomAttribute<TabelaAttribute>();
        if (tabela != null && !string.IsNullOrEmpty(tabela.Nome))
        {
            nome = tabela.Nome;
        }

        var Campos = dado.GetType().GetProperties();

        var sql = $"insert into {nome} (";
        List<string> colsDb = new List<string>();
        List<string> colsDbParameter = new List<string>();

        foreach (var campo in Campos)
        {
            var persisteCampo = campo.GetCustomAttribute<CamposAttribute>();
            if (persisteCampo != null)
            {
                if(campo.GetValue(dado) != null)
                {
                    var nomeCampo = string.IsNullOrEmpty(persisteCampo.NomeColuna) ? campo.Name : persisteCampo.NomeColuna;
                    colsDb.Add(nomeCampo);
                    colsDbParameter.Add($"@{nomeCampo}");
                }
            }
        }

        sql += string.Join(",", colsDb.ToArray());

        sql += ") values (";

        sql += string.Join(",", colsDbParameter.ToArray());
        sql += ")";

        return sql;
    }

    public static string BuilderUpdate<T>(T dado)
    {
        var nome = $"{dado.GetType().Name.ToLower()}s";
        var tabela = dado.GetType().GetCustomAttribute<TabelaAttribute>();
        if (tabela != null && !string.IsNullOrEmpty(tabela.Nome))
        {
            nome = tabela.Nome;
        }

        var Campos = dado.GetType().GetProperties();

        var sql = $"update {nome} set ";
        List<string> colsDb = new List<string>();

        PropertyInfo pkProperty = null;
        foreach (var campo in Campos)
        {
            var pkAttr = campo.GetCustomAttribute<PkAttribute>();
            if (pkAttr != null) pkProperty = campo;

            var persisteCampo = campo.GetCustomAttribute<CamposAttribute>();
            if (persisteCampo != null)
            {
                var nameCampo = string.IsNullOrEmpty(persisteCampo.NomeColuna) ? campo.Name : persisteCampo.NomeColuna;
                if(campo.GetValue(dado) != null)
                    colsDb.Add($"{nameCampo}=@{nameCampo}");
            }
        }

        sql += string.Join(",", colsDb.ToArray());

        if(pkProperty == null) throw new Exception("Esta entidade não foi definida uma chave primário, coloque o atributo [Pk]");
        
        var pk = pkProperty.GetCustomAttribute<PkAttribute>();

        sql += $" where {pk.Nome}=@{pk.Nome}";

        return sql;
    }

    public static string BuilderSelect<T>(string sqlWhere = null)
    {
        var dado = Activator.CreateInstance<T>();
        var nome = $"{dado.GetType().Name.ToLower()}s";
        var tabela = dado.GetType().GetCustomAttribute<TabelaAttribute>();
        if (tabela != null && !string.IsNullOrEmpty(tabela.Nome))
        {
            nome = tabela.Nome;
        }
        if(!string.IsNullOrEmpty(sqlWhere)) sqlWhere = $" {sqlWhere}";

        return $"select {nome}.* from {nome}{sqlWhere}";
    }

    public static string BuilderDelete<T>(T dado)
    {
        var nome = $"{dado.GetType().Name.ToLower()}s";
        var tabela = dado.GetType().GetCustomAttribute<TabelaAttribute>();
        if (tabela != null && !string.IsNullOrEmpty(tabela.Nome))
        {
            nome = tabela.Nome;
        }

        var campos = dado.GetType().GetProperties();

        var sql = $"delete from {nome}";
        List<string> colsDb = new List<string>();

        PropertyInfo pkProperty = null;
        foreach (var campo in campos)
        {
            var pkAttr = campo.GetCustomAttribute<PkAttribute>();
            if (pkAttr != null)
            {
                pkProperty = campo;
                break;
            }
        }

        if(pkProperty == null) throw new Exception("Esta entidade não foi definida uma chave primário, coloque o atributo [Pk]");
        
        var pk = pkProperty.GetCustomAttribute<PkAttribute>();
        var value = Convert.ToInt32(pkProperty.GetValue(dado));
        sql += $" where {pk.Nome}={value}";

        return sql;
    }
    public static SqlParameter GetBuilderValue<T>(T obj, string sqlParameter, string objPropriety)
    {
        var value = obj.GetType().GetProperty(objPropriety).GetValue(obj);
        if(value == null) return null;
        var param = new SqlParameter(sqlParameter, GetDbType(value));
        param.Value = value;
        return param;
    }

    private static SqlDbType GetDbType(object value)
    {
        var result = SqlDbType.VarChar;
        try
        {
            Type type = value.GetType();

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Object:
                    result = SqlDbType.Variant;
                    break;
                case TypeCode.Boolean:
                    result = SqlDbType.Bit;
                    break;
                case TypeCode.Char:
                    result = SqlDbType.NChar;
                    break;
                case TypeCode.SByte:
                    result = SqlDbType.SmallInt;
                    break;
                case TypeCode.Byte:
                    result = SqlDbType.TinyInt;
                    break;
                case TypeCode.Int16:
                    result = SqlDbType.SmallInt;
                    break;
                case TypeCode.UInt16:
                    result = SqlDbType.Int;
                    break;
                case TypeCode.Int32:
                    result = SqlDbType.Int;
                    break;
                case TypeCode.UInt32:
                    result = SqlDbType.BigInt;
                    break;
                case TypeCode.Int64:
                    result = SqlDbType.BigInt;
                    break;
                case TypeCode.UInt64:
                    result = SqlDbType.Decimal;
                    break;
                case TypeCode.Single:
                    result = SqlDbType.Real;
                    break;
                case TypeCode.Double:
                    result = SqlDbType.Float;
                    break;
                case TypeCode.Decimal:
                    result = SqlDbType.Money;
                    break;
                case TypeCode.DateTime:
                    result = SqlDbType.DateTime;
                    break;
                case TypeCode.String:
                    result = SqlDbType.VarChar;
                    break;
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return result;
    }

    public static List<SqlParameter> BuilderParameters<T>(T obj, bool includePk = false)
        {
            var campos = obj.GetType().GetProperties();

            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var campo in campos)
            {
                if(includePk)
                {
                    var pkCampos = campo.GetCustomAttribute<PkAttribute>();
                    if (pkCampos != null)
                    {
                        var nameField = string.IsNullOrEmpty(pkCampos.Nome) ? campo.Name : pkCampos.Nome;
                        var parameter = GetBuilderValue(obj, $"@{nameField}", campo.Name);
                        if(parameter != null)
                            parameters.Add(parameter);
                    }
                }

                var persisteCampo = campo.GetCustomAttribute<CamposAttribute>();
                if (persisteCampo != null)
                {
                    var nameField = string.IsNullOrEmpty(persisteCampo.NomeColuna) ? campo.Name : persisteCampo.NomeColuna;
                    var parameter = GetBuilderValue(obj, $"@{nameField}", campo.Name);
                    if(parameter != null)
                        parameters.Add(parameter);
                }
            }

            return parameters;
        }
    }
}