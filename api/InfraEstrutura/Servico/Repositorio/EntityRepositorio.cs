﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public class EntityRepositorio : IEntityRepositorio
    {
        private readonly EntityContext context;

        public EntityRepositorio(EntityContext context)
        {
            this.context = context;
        }
        public async Task Alterar<T>(T usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Excluir<T>(T usuario)
        {
            context.Remove(usuario);
            await context.SaveChangesAsync();
        }

        public async Task Salvar<T>(T usuario) 
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<T> BuscarPorId<T>(int id) where T : class
        {
            var entity = await context.Set<T>().FindAsync(id);
            if(entity != null)
                context.Entry(entity).State = EntityState.Detached;
            
            return entity;
        }

        public async Task<List<T>> BuscarTodos<T>() where T : class
        {
             return await context.Set<T>().AsNoTracking<T>().ToListAsync();
        }
    }
}