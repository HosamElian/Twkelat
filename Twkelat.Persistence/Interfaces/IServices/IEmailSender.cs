using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Persistence.Interfaces.IServices
{
	public interface IEmailSender
	{
		void Send(string msg, string email);
    }
}
