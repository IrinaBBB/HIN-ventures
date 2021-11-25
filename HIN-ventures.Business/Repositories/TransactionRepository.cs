using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.DataAccess.Data;
//using BlockIoLib;
using HIN_ventures.Business.Repositories.IRepositories;

namespace HIN_ventures.Business.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        //private readonly BlockIo _blockIo = new("9da8-f106-e0c7-e733", "H5sbN8Ra34KjgaTFEBcN"); // Dogecoin (TESTNET!)
        public TransactionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void TransferOneCoin()
        {
            //// send a coin to between two addresses
            //var preparedTransaction = _blockIo.PrepareTransaction(
            //    new { amounts = "1", from_addresses = "2N1spDd7mDaBfHbCRKGq9p28BwBo2XjmrEF", to_addresses = "2NBuGkA8bdxsH4GhQaURwsz3rmfeX4Mrekt" });

            //// create and sign the prepared transaction
            //var transactionData = _blockIo.CreateAndSignTransaction(preparedTransaction);
       
            //// submit the transaction
            //_blockIo.SubmitTransaction(new { transaction_data = transactionData });
        }
    }
}
