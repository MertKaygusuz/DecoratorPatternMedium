using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Models
{
    public class AddToShoppingCartModel : IValidatableObject
    {
        [Required(ErrorMessage = "Ürünü seçiniz")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Ürün adedini seçiniz")]
        public int? Count { get; set; }

        [Required(ErrorMessage = "Lütfen ürünü ekleyeceğiniz sepet türünü belirleyiniz.")]
        public int? UserShoppingCartId { get; set; }

        public string ProductName { get; set; }

        //buradaki kontrol data annotations kullanılarak da yapılabilir. Çeşitlilik olması açısından bu yöntem tercih edildi.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Count < 1)
                yield return new ValidationResult("Sepete eklenecek ürün adedi en az 1 adet olmalıdır.", new[] { nameof(Count) });
        }
    }
}
