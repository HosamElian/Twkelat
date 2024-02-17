using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Core.Interfaces
{
    public interface IBlock
    {
        byte[] Data { get; }
        byte[] Hash { get; set; }
        byte[] PrevHash { get; set; }
        int Nonce { get; set; }
        DateTime TimeStamp { get; set; }
    }



    public interface IBankAccount
    {
        bool Pay(string ammoun);
        bool Insert(string  ammoun);
    }







}
