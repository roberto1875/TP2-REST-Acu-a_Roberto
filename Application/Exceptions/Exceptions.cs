﻿

namespace Application.Exceptions
{
    public class Exceptions
    {
        public class SaleNotFoundException : Exception
        {
            public SaleNotFoundException(int id)
                : base($"No se encontró ventas con el ID {id}.")
            {
            }
        }

        public class ConflictProductException : Exception
        {
            public ConflictProductException()
                : base($"Conflicto, el producto ya existe.")
            {
            }
        }

        public class ProductNotFoundException : Exception
        {
            public ProductNotFoundException()
                : base($"Producto no encontrado.")
            {
            }
        }

        public class BadRequestException : Exception
        {
            public BadRequestException(string message)
                : base(message)
            {
            }
        }

        public class SaleProductException : Exception
        {
            public SaleProductException(string message)
                : base(message)
            {
            }
        }



    }
}
