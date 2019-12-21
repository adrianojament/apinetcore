using System;
using System.Collections.Generic;
using alterdata.votador.api.Models;

namespace alterdata.votador.api.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundo);
        void Alterar(FundoCapital fundo);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital ObterPorId(Guid id);
        void RemoverFundo(FundoCapital fundo);
    }
}