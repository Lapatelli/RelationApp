using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure.Configurations
{
    public class RelationConfiguration : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {

            builder.ToTable("tblRelation");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ArrivalBetween).HasColumnType("datetime");

            builder.Property(e => e.ArrivalBetweenAnd).HasColumnType("datetime");

            builder.Property(e => e.ArrivalName)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.BankAccount)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.BankBic)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.BankName)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CarrierCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ChamberOfCommerce)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CustomerCode)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.DebtorNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.DefaultCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DefaultCountry)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DefaultPostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DefaultStreet)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.DepartureBetween).HasColumnType("datetime");

            builder.Property(e => e.DepartureBetweenAnd).HasColumnType("datetime");

            builder.Property(e => e.DepartureName)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.DigitalFreightDocumentEmailTemplateId).HasColumnName("DigitalFreightDocumentEMailTemplateId");

            builder.Property(e => e.EmailAddress)
                .HasColumnName("EMailAddress")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.EmergencyNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.FaxNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.GeneralLedgerAccount)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Imaddress)
                .HasColumnName("IMAddress")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.InvoiceEmailAddress)
                .HasColumnName("InvoiceEMailAddress")
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.InvoiceGroupByTransportOrderColumnName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.InvoiceTo)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.MobileNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedAt).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.PriceListName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PriceListNameForCollecting)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Remarks).IsUnicode(false);

            builder.Property(e => e.SendDigitalFreightDocumentsByEmail).HasColumnName("SendDigitalFreightDocumentsByEMail");

            builder.Property(e => e.SendFreightStatusUpdateByEmail).HasColumnName("SendFreightStatusUpdateByEMail");

            builder.Property(e => e.SkypeAddress)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.SupplyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TelephoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.VatName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.VatNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.VendorNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
