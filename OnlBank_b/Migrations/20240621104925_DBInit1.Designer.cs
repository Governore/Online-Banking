﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlBank_b.Models;

#nullable disable

namespace OnlBank_b.Migrations
{
    [DbContext(typeof(BankingonlineContext))]
    [Migration("20240621104925_DBInit1")]
    partial class DBInit1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("OnlBank_b.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("AccountId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AccountNumber" }, "AccountNumber")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "UserId");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AdminId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "RoleId");

                    b.HasIndex(new[] { "Username" }, "Username")
                        .IsUnique();

                    b.ToTable("admins", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Adminrole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleName" }, "RoleName")
                        .IsUnique();

                    b.ToTable("adminroles", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Helprequest", b =>
                {
                    b.Property<int>("HelpRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("HelpRequestId"));

                    b.Property<string>("HelpRequestContent")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RequestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("HelpRequestId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId")
                        .HasDatabaseName("UserId1");

                    b.ToTable("helprequests", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Otp", b =>
                {
                    b.Property<int>("Otpid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("OTPId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Otpid"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Otpcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("OTPCode");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("Otpid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId")
                        .HasDatabaseName("UserId2");

                    b.ToTable("otp", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<DateTime?>("RequestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("RequestType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("RequestId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId")
                        .HasDatabaseName("UserId3");

                    b.ToTable("requests", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Tokenblacklist", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TokenId"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("TokenId")
                        .HasName("PRIMARY");

                    b.ToTable("tokenblacklist", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int(11)");

                    b.Property<decimal?>("Amount")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<DateTime?>("TransactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<string>("TransactionType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("TransactionId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AccountId" }, "AccountId");

                    b.HasIndex(new[] { "AdminId" }, "AdminId");

                    b.HasIndex(new[] { "UserId" }, "UserId")
                        .HasDatabaseName("UserId4");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Transfertransaction", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TransferId"));

                    b.Property<decimal?>("Amount")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<int?>("FromAccountId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ToAccountId")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("TransferDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.HasKey("TransferId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FromAccountId" }, "FromAccountId");

                    b.HasIndex(new[] { "ToAccountId" }, "ToAccountId");

                    b.ToTable("transfertransactions", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool?>("AccountLocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("FailedLoginAttempts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("PasswordResetExpiry")
                        .HasColumnType("datetime");

                    b.Property<string>("PasswordResetToken")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Username" }, "Username")
                        .IsUnique()
                        .HasDatabaseName("Username1");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OnlBank_b.Models.Account", b =>
                {
                    b.HasOne("OnlBank_b.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("accounts_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlBank_b.Models.Admin", b =>
                {
                    b.HasOne("OnlBank_b.Models.Adminrole", "Role")
                        .WithMany("Admins")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("admins_ibfk_1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OnlBank_b.Models.Helprequest", b =>
                {
                    b.HasOne("OnlBank_b.Models.User", "User")
                        .WithMany("Helprequests")
                        .HasForeignKey("UserId")
                        .HasConstraintName("helprequests_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlBank_b.Models.Otp", b =>
                {
                    b.HasOne("OnlBank_b.Models.User", "User")
                        .WithMany("Otps")
                        .HasForeignKey("UserId")
                        .HasConstraintName("otp_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlBank_b.Models.Request", b =>
                {
                    b.HasOne("OnlBank_b.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .HasConstraintName("requests_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlBank_b.Models.Transaction", b =>
                {
                    b.HasOne("OnlBank_b.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("admintransactions_ibfk_3");

                    b.HasOne("OnlBank_b.Models.Admin", "Admin")
                        .WithMany("Transactions")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("admintransactions_ibfk_1");

                    b.HasOne("OnlBank_b.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("admintransactions_ibfk_2");

                    b.Navigation("Account");

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlBank_b.Models.Transfertransaction", b =>
                {
                    b.HasOne("OnlBank_b.Models.Account", "FromAccount")
                        .WithMany("TransfertransactionFromAccounts")
                        .HasForeignKey("FromAccountId")
                        .HasConstraintName("transfertransactions_ibfk_1");

                    b.HasOne("OnlBank_b.Models.Account", "ToAccount")
                        .WithMany("TransfertransactionToAccounts")
                        .HasForeignKey("ToAccountId")
                        .HasConstraintName("transfertransactions_ibfk_2");

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("OnlBank_b.Models.Account", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("TransfertransactionFromAccounts");

                    b.Navigation("TransfertransactionToAccounts");
                });

            modelBuilder.Entity("OnlBank_b.Models.Admin", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("OnlBank_b.Models.Adminrole", b =>
                {
                    b.Navigation("Admins");
                });

            modelBuilder.Entity("OnlBank_b.Models.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Helprequests");

                    b.Navigation("Otps");

                    b.Navigation("Requests");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
