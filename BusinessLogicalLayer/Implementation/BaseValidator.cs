using BusinessLogicalLayer.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Implementation
{
    public class BaseValidator<T>
    {
        private StringBuilder errors = new StringBuilder();

        public void AddError(string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                errors.AppendLine(error);
            }
        }

        public virtual Response Validate(T item)
        {
            return CheckErrors();
        }

        private Response CheckErrors()
        {
            Response response = new Response();
                
            if (errors.Length != 0)
            {
                response.Sucesso = false;
                response.Mensagem = errors.ToString();
                return response;
            }

            response.Sucesso = true;
            response.Mensagem = "Validação efetuada com sucesso.";
            return response;
        }
    }
}
