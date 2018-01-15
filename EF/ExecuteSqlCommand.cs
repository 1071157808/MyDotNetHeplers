protected override void Seed(Context context)
{
    context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Billing UNIQUE(BillingAddressId)");
    context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Delivery UNIQUE(DeliveryAddressId)");
}
