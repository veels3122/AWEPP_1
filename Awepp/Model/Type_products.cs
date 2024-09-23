using System.ComponentModel.DataAnnotations;

namespace AWEPP.Model
{
    public class Type_products
    {
        [Key]
        public int Id { get; set; }
        public required int Producto { get; set; }
        public required string Descripcion { get; set; }

    }
}
