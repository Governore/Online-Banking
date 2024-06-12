using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OnlBank_b.Models;

public partial class BankingonlineContext : DbContext
{
    public BankingonlineContext()
    {
    }

    public BankingonlineContext(DbContextOptions<BankingonlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Adminrole> Adminroles { get; set; }

    public virtual DbSet<Admintransaction> Admintransactions { get; set; }

    public virtual DbSet<Helprequest> Helprequests { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Tokenblacklist> Tokenblacklists { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transfertransaction> Transfertransactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=bankingonline;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.AccountNumber, "AccountNumber").IsUnique();

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.AccountId).HasColumnType("int(11)");
            entity.Property(e => e.AccountNumber).HasMaxLength(20);
            entity.Property(e => e.Balance)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("accounts_ibfk_1");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admins");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.AdminId).HasColumnType("int(11)");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("admins_ibfk_1");
        });

        modelBuilder.Entity<Adminrole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("adminroles");

            entity.HasIndex(e => e.RoleName, "RoleName").IsUnique();

            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Admintransaction>(entity =>
        {
            entity.HasKey(e => e.AdminTransactionId).HasName("PRIMARY");

            entity.ToTable("admintransactions");

            entity.HasIndex(e => e.AccountId, "AccountId");

            entity.HasIndex(e => e.AdminId, "AdminId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.AdminTransactionId).HasColumnType("int(11)");
            entity.Property(e => e.AccountId).HasColumnType("int(11)");
            entity.Property(e => e.AdminId).HasColumnType("int(11)");
            entity.Property(e => e.Amount).HasPrecision(15, 2);
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Account).WithMany(p => p.Admintransactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("admintransactions_ibfk_3");

            entity.HasOne(d => d.Admin).WithMany(p => p.Admintransactions)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("admintransactions_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Admintransactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("admintransactions_ibfk_2");
        });

        modelBuilder.Entity<Helprequest>(entity =>
        {
            entity.HasKey(e => e.HelpRequestId).HasName("PRIMARY");

            entity.ToTable("helprequests");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.HelpRequestId).HasColumnType("int(11)");
            entity.Property(e => e.HelpRequestContent).HasColumnType("text");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Helprequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("helprequests_ibfk_1");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.Otpid).HasName("PRIMARY");

            entity.ToTable("otp");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Otpid)
                .HasColumnType("int(11)")
                .HasColumnName("OTPId");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Otpcode)
                .HasMaxLength(10)
                .HasColumnName("OTPCode");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Otps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("otp_ibfk_1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.RequestId).HasColumnType("int(11)");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("requests_ibfk_1");
        });

        modelBuilder.Entity<Tokenblacklist>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PRIMARY");

            entity.ToTable("tokenblacklist");

            entity.Property(e => e.TokenId).HasColumnType("int(11)");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(500);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.AccountId, "AccountId");

            entity.Property(e => e.TransactionId).HasColumnType("int(11)");
            entity.Property(e => e.AccountId).HasColumnType("int(11)");
            entity.Property(e => e.Amount).HasPrecision(15, 2);
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("transactions_ibfk_1");
        });

        modelBuilder.Entity<Transfertransaction>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PRIMARY");

            entity.ToTable("transfertransactions");

            entity.HasIndex(e => e.FromAccountId, "FromAccountId");

            entity.HasIndex(e => e.ToAccountId, "ToAccountId");

            entity.Property(e => e.TransferId).HasColumnType("int(11)");
            entity.Property(e => e.Amount).HasPrecision(15, 2);
            entity.Property(e => e.FromAccountId).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.ToAccountId).HasColumnType("int(11)");
            entity.Property(e => e.TransferDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FromAccount).WithMany(p => p.TransfertransactionFromAccounts)
                .HasForeignKey(d => d.FromAccountId)
                .HasConstraintName("transfertransactions_ibfk_1");

            entity.HasOne(d => d.ToAccount).WithMany(p => p.TransfertransactionToAccounts)
                .HasForeignKey(d => d.ToAccountId)
                .HasConstraintName("transfertransactions_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.UserId).HasColumnType("int(11)");
            entity.Property(e => e.AccountLocked).HasDefaultValueSql("'0'");
            entity.Property(e => e.FailedLoginAttempts)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PasswordResetExpiry).HasColumnType("datetime");
            entity.Property(e => e.PasswordResetToken).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
