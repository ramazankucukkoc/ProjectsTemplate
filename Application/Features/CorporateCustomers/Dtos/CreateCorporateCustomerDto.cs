﻿namespace Application.Features.CorporateCustomers.Dtos
{
    public class CreateCorporateCustomerDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }//Vergi No



    }
}
