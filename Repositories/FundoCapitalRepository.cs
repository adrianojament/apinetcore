using System;
using System.Collections.Generic;
using System.Linq;
using alterdata.votador.api.Models;

namespace alterdata.votador.api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(x=> x.Id == fundo.Id);
                            
            _storage[index] = fundo;
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public FundoCapital ObterPorId(Guid id)
        {
            return _storage.FirstOrDefault(x => x.Id == id);
        }

        public void RemoverFundo(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}