﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public interface IEntityRepositorio
    {
        Task<T> Alterar<T>(T entityRepositorio);
        Task<T> Salvar<T>(T entityRepositorio);
        Task Excluir<T>(T entityRepositorio);
        Task<List<T>> BuscarTodos<T>(params Expression<Func<T, object>>[] includes) where T : class;
        Task<T> Buscar<T>(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes) where T : class;
        Task<List<T>> Filtrar<T>(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes) where T : class;       
    }
}