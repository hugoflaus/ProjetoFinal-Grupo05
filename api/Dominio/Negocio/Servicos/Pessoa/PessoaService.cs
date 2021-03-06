﻿using api.Dominio.Autenticação;
using api.Dominio.Negocio.Builder;
using api.Dominio.Entidade.Usuario;
using api.Dominio.ViewModel.Pessoa;
using System;
using System.Threading.Tasks;
using api.InfraEstrutura.Servico.Repositorio;
using System.Collections.Generic;
using api.InfraEstrutura.Servico.Repositorio.Usuario;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public class PessoaService 
    {
        private IPessoaRepositorio  repositorio;
        private IEntityRepositorio  entityRepositorio;
        public PessoaService(IPessoaRepositorio repositorio, IEntityRepositorio entityRepositorio)
        {
            this.repositorio = repositorio;
            this.entityRepositorio = entityRepositorio;
        }

        public async Task<PessoaJwt> LoginPessoa(PessoaLogin pessoa, IToken token)
        {

            if(pessoa.Login.Length >=11)
            {
                if(!ValidaCPF.ValidarCPF(pessoa.Login)) 
                    throw new Exception("CPF inválido !");
            }

            var pessoaLogada = await repositorio.BuscarLoginSenha(pessoa.Login, pessoa.Senha);

            if (pessoaLogada == null)
                throw new Exception("Usuario e Login invalidos");

            return new PessoaJwt()
            {
                Id = pessoaLogada.Id,
                Name = pessoaLogada.Nome,
                Documento = pessoaLogada.Documento,
                Tipo = pessoaLogada.Tipo.ToString(),
                Token = token.GerarToken(pessoaLogada)
            };
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var pessoas = await entityRepositorio.BuscarTodos<Pessoa>();
            if (pessoas == null)
                throw new Exception("Usuario não encontrado.");
            
            return pessoas;   
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            var pessoa = await entityRepositorio.Buscar<Pessoa>(pessoa => pessoa.Id == id);
            if (pessoa == null)
                throw new Exception("Usuario não encontrado.");

            return pessoa;   
        }

        public async Task VerificaUsuarioCadastrado(string Documento){
            var pessoa = await entityRepositorio.Buscar<Pessoa>(pessoa => pessoa.Documento == Documento);
            if(pessoa != null)
                throw new Exception("Usuário já cadastrado.");
        }

        public async Task<Pessoa> Salvar(PessoaSalvar pessoa)
        {
            var pessoaBuilder = BuilderEntidade.ConverteEntidade<Pessoa>(pessoa);
            var pessoaBD = await entityRepositorio.Salvar<Pessoa>(pessoaBuilder);
            return pessoaBD;
        }

        public async Task<Pessoa> Alterar(int id, PessoaAlterar pessoa)
        {
            var pessoaAlteracao = await entityRepositorio.Buscar<Pessoa>(pessoa => pessoa.Id == id);

            if (pessoaAlteracao == null)
                throw new Exception("Usuario não encontrado.");
            
            var pessoaBuilder = BuilderEntidade.ConverteEntidade<Pessoa>(pessoa);    
            pessoaBuilder.Id = pessoaAlteracao.Id;
            pessoaBuilder.Senha = pessoaAlteracao.Senha;

            return await entityRepositorio.Alterar<Pessoa>(pessoaBuilder);  
        }

        public async Task Remover(int id)
        {
            var pessoa = await entityRepositorio.Filtrar<Pessoa>(pessoa => pessoa.Id == id);

            if (pessoa == null)
                throw new Exception("Usuario não encontrado.");
            

            await entityRepositorio.Excluir(pessoa); 
        }
    }
}
