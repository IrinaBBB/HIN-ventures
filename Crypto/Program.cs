using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BlockIoLib;
using CryptoLib;
using HIN_ventures.Common;

namespace Crypto
{
    /*
     *  
        //var temp = (_blockIo.GetAddressByLabel(new { labels = "HIN-Ventures" })).Data; //viser ikke at man må ha data i https://block.io/api/simple/csharp
        //FreelancerBalance = (_blockIo.GetAddressByLabel(new { label = "FreelancerTest" })).Data; //viser ikke at man må ha data i https://block.io/api/simple/csharp
     */

    public class PaymentSystem
    {
        private readonly BlockIo blockIo;
        public PaymentSystem()
        {
            blockIo = new BlockIo("9da8-f106-e0c7-e733", "H5sbN8Ra34KjgaTFEBcN"); //"DOGECOIN"
        }

        public void TestTransfer()
        {
            var data = blockIo.GetBalance().Data;
            Console.WriteLine(data.ToString());
            Console.ReadLine();
            // send a coin to between two addresses
            var preparedTransaction = blockIo.PrepareTransaction(
                new { amounts = "1", from_addresses = SD.HinCryptoAddress, to_addresses = "2NBuGkA8bdxsH4GhQaURwsz3rmfeX4Mrekt" });
            //_blockIo.PrepareTransaction(new { amounts = "1", from_labels = "HIN-Ventures", to_labels = "FreelancerTest" });

            // create and sign the prepared transaction
            var transactionData = blockIo.CreateAndSignTransaction(preparedTransaction);

            // submit the transaction
            var response = blockIo.SubmitTransaction(new { transaction_data = transactionData }).Data;
        }

        public void GetCurrentAccounts()
        {
            Console.WriteLine(blockIo.GetAccountInfo().Data);
            Console.ReadLine();
        }

        public void GetUsers()
        {
            Console.WriteLine(blockIo.GetUsers().Data);
        }

        public void Transfer(TransferByLabel transfer)
        {
            //Console.WriteLine("Current Price: " + blockIo.GetCurrentPrice(new { base_price = "DOGE" }).Data); //NOT FOR TESTNET

            var preparedTransaction = blockIo.PrepareTransaction(
                new { amounts = transfer.Amount, from_labels = transfer.FromLabel, to_labels = transfer.ToLabel });

            // create and sign the prepared transaction
            var transactionData = blockIo.CreateAndSignTransaction(preparedTransaction);

            // submit the transaction
            var response = blockIo.SubmitTransaction(new { transaction_data = transactionData }).Data;


            Console.WriteLine($"New Balance for {transfer.ToLabel}: " + blockIo.GetAddressBalance(new { labels = transfer.ToLabel }).Data);
            Console.WriteLine($"New Balance for {transfer.FromLabel}" + blockIo.GetAddressBalance(new { labels = transfer.FromLabel }).Data);
            //Console.WriteLine("Received Transactions: " + blockIo.GetTransactions(new { type = "received" }).Data);
        }

        public void Archive(string label)
        {
            blockIo.ArchiveAddresses(new { labels = label });
        }

    }


    public class Program
    {

        static void Main(string[] args)
        {
            PaymentSystem payment = new PaymentSystem();
            //payment.GetCurrentAccounts();
            payment.GetUsers();
            
            Console.WriteLine("Enter which user(label) you would like to transfer from : ");
            string fromUser = Console.ReadLine();

            Console.WriteLine("Enter which user(label) you would like to transfer to : ");
            string toUser = Console.ReadLine();
            
            Console.WriteLine("Enter Amount you would like to transfer(and press enter): ");
            string amount = Console.ReadLine();


            TransferByLabel crypto = new TransferByLabel()
            {
                FromLabel = fromUser,
                ToLabel = toUser,
                Amount = amount

            };

            payment.Transfer(crypto);


        }
    }


    public class Transfer
    {
        public string ApiKey { get; set; }

        public string FromLabel { get; set; }
        public string ToLabel { get; set; }
        public string Amounts { get; set; }
    }
}
